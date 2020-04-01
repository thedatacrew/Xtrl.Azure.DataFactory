using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public class ActivityModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("dependsOn")]
        public DependsOnModel[] DependsOn { get; set; }

        [JsonProperty("userProperties")]
        public object[] UserProperties { get; set; }

        [JsonProperty("typeProperties")]
        public TypePropertiesModel TypeProperties { get; set; }
    }
}