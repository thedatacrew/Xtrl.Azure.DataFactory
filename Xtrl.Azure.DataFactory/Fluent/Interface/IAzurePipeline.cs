using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Fluent.Interface
{

    public interface IAzurePipeline
    {
        IAzureExecutePipeline AddExecutePipeline(string name, string referenceName, string parameters);
        string ToJsonString();
        string ToJsonString(JsonSerializerSettings settings);
    }

}