using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public class Folder
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }


}