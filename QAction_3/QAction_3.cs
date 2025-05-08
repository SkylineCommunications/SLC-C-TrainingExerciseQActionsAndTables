using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using QAction_1;
using Skyline.DataMiner.Scripting;
using System.Globalization;

/// <summary>
/// DataMiner QAction Class: Poll Data.
/// </summary>
public static class QAction
{
	/// <summary>
	/// The QAction entry point.
	/// </summary>
	/// <param name="protocol">Link with SLProtocol process.</param>
	public static void Run(SLProtocolExt protocol)
	{
		try
		{
			var path = @"C:\Users\AlmaBA\source\repos\SLC-C-TrainingExerciseQActionsAndTables\Documentation\Data.json";

			if (File.Exists(path))
			{
				var data = File.ReadAllText(path, Encoding.UTF8);
				var transportStreamsObject = JsonConvert.DeserializeObject<TransportStreamsObject>(data);

				List<TransportstreamsQActionRow> transportStreams = new List<TransportstreamsQActionRow>();
				List<ServicesQActionRow> services = new List<ServicesQActionRow>();

				if (transportStreamsObject != null)
				{
					foreach (var tstream in transportStreamsObject.TransportStreams)
					{
						transportStreams.Add(FillTransportStreamsTable(tstream));
						foreach (var service in tstream.Services)
						{
							services.Add(FillServicesTable(service, tstream.Id));
						}
					}
					protocol.Log(Convert.ToString(DateTime.Now));
                    protocol.Log(Convert.ToString(DateTime.Now.ToOADate()));
                    protocol.transportstreams.FillArray(transportStreams.ToArray());
					protocol.services.FillArray(services.ToArray());
				}
			}
		}
		catch (Exception ex)
		{
			protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
		}
	}

	public static TransportstreamsQActionRow FillTransportStreamsTable(TransportStreams tstream)
	{
		var newTransportStreamRow = new TransportstreamsQActionRow
		{
			Transportstreamsid_1001 = tstream.Id.ToString(),
			Transportstreamsname_1002 = tstream.Name,
			Transportstreamsmulticast_1003 = tstream.Multicast,
			Transportstreamssourceip_1004 = tstream.SoureceIp,
			Transportstreamsnetworkid_1005 = tstream.NetworkId.ToString(),
			Transportstreamslastupdate_1006 = DateTime.Now.ToOADate(),
		};

		return newTransportStreamRow;
	}

	public static ServicesQActionRow FillServicesTable(ServiceObject service, int ts)
	{
		var newService = new ServicesQActionRow
		{
			Servicesid_2001 = service.Id,
			Servicesname_2002 = service.Name,
			Servicestype_2003 = service.Type,
			Servicesprovider_2004 = service.Provider,
			Serviceslastupdate_2005 = DateTime.Now.ToOADate(),
			Servicestransportstreamid_2006 = ts,
		};

		return newService;
	}
}