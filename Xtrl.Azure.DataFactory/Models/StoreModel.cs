using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public class StoreModel

    {
        [JsonProperty("referenceName")]
        public string ReferenceName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}