namespace QAction_1
{
	using System.Collections.Generic;
	using Newtonsoft.Json;

	public class TransportStreamsObject
    {
        [JsonProperty(propertyName: "transport_streams")]
        public List<TransportStreams> TransportStreams { get; set; }
    }
}