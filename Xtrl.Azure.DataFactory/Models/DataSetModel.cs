using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public class DataSetModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("properties")]
        public PropertiesModel Properties { get; set; }
    }
}
