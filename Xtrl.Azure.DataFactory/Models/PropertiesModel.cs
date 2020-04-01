using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public class PropertiesModel
    {
        [JsonProperty("description")]
        public string PropertyDescription { get; set; }

        [JsonProperty("activities")]
        public ActivityModel[] Activities { get; set; }

        [JsonProperty("linkedServiceName")]
        public LinkedServiceName LinkedServiceName { get; set; }

        [JsonProperty("folder")]
        public Folder Folder { get; set; }

        [JsonProperty("annotations")]
        public string[] Annotations { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("typeProperties")]
        public TypePropertiesModel TypeProperties { get; set; }

        [JsonProperty("connectVia")]
        public ConnectViaModel ConnectVia { get; set; }

        [JsonProperty("schema")]
        public Schema[] Schema { get; set; }
    }

}