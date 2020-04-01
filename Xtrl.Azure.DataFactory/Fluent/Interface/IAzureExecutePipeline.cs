using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Fluent.Interface
{
    public interface IAzureExecutePipeline

    {
        IAzureExecutePipeline AddExecutePipeline(string name, string referenceName, string parameters);
        IAzureWrite ToJson();
        IAzureWrite ToJson(JsonSerializerSettings settings);

    }

}