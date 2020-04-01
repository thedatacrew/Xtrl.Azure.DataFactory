using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public interface IAzureLinkedServiceModel
    {
        string Name { get; set; }
        string Type { get; set; }
        PropertiesModel Properties { get; set; }
        string LinkedServiceDescription { get; set; }
    }

    public class AzureLinkedServiceModel : IAzureLinkedServiceModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public PropertiesModel Properties { get; set; }

        [JsonProperty("description")]
        public string LinkedServiceDescription { get; set; }

    }
}
