using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public  class AccountKeyModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("store")]
        public StoreModel Store { get; set; }

        [JsonProperty("secretName")]
        public string SecretName { get; set; }
    }
}