namespace Xtrl.Azure.DataFactory.Fluent.Interface
{
    public interface IAzureLinkedServiceConnectionInfo
    {
        IAzureLinkedServiceCredentials ConnectionString(string connectionString);
        IAzureSerializeAction BaseUrl(string baseUrl);
    }
}