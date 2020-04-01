using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Fluent.Interface
{
    public interface IAzureLinkedServiceIntegrationRuntime
    {
        IAzureSerializeAction ConnectVia(string integrationRuntimeReference);
        IAzureWrite ToJson();
        IAzureWrite ToJson(JsonSerializerSettings settings);

    }
}