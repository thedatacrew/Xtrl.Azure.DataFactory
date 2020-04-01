using System.Collections.Generic;
using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Models
{
    public class TypePropertiesModel
    {
        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }

        [JsonProperty("encryptedCredential")]
        public string EncryptedCredential { get; set; }

        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }

        [JsonProperty("password")]
        public PasswordModel Password { get; set; }

        [JsonProperty("pipeline")]
        public PipelineReferenceModel PipelineReference { get; set; }

        [JsonProperty("waitOnCompletion")]
        public bool? WaitOnCompletion { get; set; }

        [JsonProperty("parameters")]
        public IDictionary<string, object> Parameters { get; set; }
        
        [JsonProperty("accountKey")]
        public AccountKeyModel AccountKey { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("columnDelimiter")]
        public string ColumnDelimiter { get; set; }

        [JsonProperty("rowDelimiter")]
        public string RowDelimiter { get; set; }

        [JsonProperty("encodingName")]
        public string EncodingName { get; set; }

        [JsonProperty("escapeChar")]
        public string EscapeChar { get; set; }

        [JsonProperty("firstRowAsHeader")]
        public bool? FirstRowAsHeader { get; set; }

        [JsonProperty("quoteChar")]
        public string QuoteChar { get; set; }

    }

}