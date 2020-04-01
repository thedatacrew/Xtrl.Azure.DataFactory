using Xtrl.Azure.DataFactory.Models;

namespace Xtrl.Azure.DataFactory.Fluent.Interface
{
    public interface IAzureLinkedService
    {
        IAzureSerializeAction BaseUrl(string baseUrl);
        IAzureLinkedServiceCredentials ConnectionString(string connectionString);
        AzureLinkedServiceModel GetAzureLinkedService();
    }
}