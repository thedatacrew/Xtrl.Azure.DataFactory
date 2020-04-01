using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public class PipelineModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("properties")]
        public PropertiesModel Properties { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

}