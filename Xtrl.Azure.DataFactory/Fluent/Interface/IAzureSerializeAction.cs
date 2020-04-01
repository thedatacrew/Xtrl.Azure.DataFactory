using Newtonsoft.Json;

namespace Xtrl.Azure.DataFactory.Fluent.Interface
{
    public interface IAzureSerializeAction
    {
        IAzureWrite ToJson();
        IAzureWrite ToJson(JsonSerializerSettings settings);

    }
}