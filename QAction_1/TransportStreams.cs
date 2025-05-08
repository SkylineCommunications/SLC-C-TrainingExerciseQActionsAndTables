namespace QAction_1
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;

	public class TransportStreams
    {
        [JsonProperty(propertyName: "ts_id")]
        public int Id { get; set; }

        [JsonProperty(propertyName: "ts_name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "multicast")]
        public string Multicast { get; set; }

        [JsonProperty(propertyName: "sourceIp")]
        public string SoureceIp { get; set; }

        [JsonProperty(propertyName: "network_id")]
        public int NetworkId { get; set; }

        [JsonProperty(propertyName: "last_update")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty(propertyName: "services")]
        public List<ServiceObject> Services { get; set; }
    }
}
