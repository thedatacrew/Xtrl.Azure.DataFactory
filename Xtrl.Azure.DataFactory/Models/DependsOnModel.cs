using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public class DependsOnModel
    {
        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("dependencyConditions")]
        public string[] DependencyConditions { get; set; }
    }
}