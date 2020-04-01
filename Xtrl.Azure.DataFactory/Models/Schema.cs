using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public class Schema
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}