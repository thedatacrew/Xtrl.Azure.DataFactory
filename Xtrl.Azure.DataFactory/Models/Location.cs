using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public class Location
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("folderPath")]
        public string FolderPath { get; set; }

        [JsonProperty("container")]
        public string Container { get; set; }
    }
}