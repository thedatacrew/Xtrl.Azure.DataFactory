using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xtrl.Azure.DataFactory.Fluent
{
    public static class JsonSerializer
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            DateParseHandling = DateParseHandling.None,
            Formatting = Formatting.Indented,
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        public static readonly JsonSerializerSettings MinifiedSettings = new JsonSerializerSettings
        {
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            DateParseHandling = DateParseHandling.None,
            Formatting = Formatting.None,
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        public static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        //public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public static string ToJsonString<T>(this T self) => JsonConvert.SerializeObject(self, JsonSerializer.Settings);
        public static string ToJsonString<T>(this T self, JsonSerializerSettings jsonSerializerSettings) => JsonConvert.SerializeObject(self, jsonSerializerSettings);

        public static T FromJson<T>(string json) => JsonConvert.DeserializeObject<T>(json, JsonSerializer.Settings);
    }
}