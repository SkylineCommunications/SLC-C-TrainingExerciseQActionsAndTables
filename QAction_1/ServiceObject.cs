namespace QAction_1
{
	using Newtonsoft.Json;

	public class ServiceObject
    {
        [JsonProperty(propertyName: "service_id")]
        public int Id { get; set; }

        [JsonProperty(propertyName: "service_name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "service_type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "service_provider")]
        public string Provider { get; set; }
    }
}