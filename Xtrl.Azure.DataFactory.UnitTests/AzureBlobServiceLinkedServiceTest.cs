using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Xtrl.Azure.DataFactory.Fluent;

namespace Xtrl.Azure.DataFactory.UnitTests
{

    [SuppressMessage("ReSharper", "StringLiteralTypo")]

    [TestFixture]
    public class AzureBlobServiceLinkedServiceTest
    {

        [TestCase()]
        public void create_new_azure_blob_store_linked_service_using_key_vault_to_store_account_key()
        {

            const string expectedData = "{\"name\":\"ls_dlsgroupdwhtest001\",\"type\":\"Microsoft.DataFactory/factories/linkedservices\",\"properties\":{\"description\":\"Azure Blob Service dlsgroupdwhtest001\",\"annotations\":[],\"type\":\"AzureBlobStorage\",\"typeProperties\":" +
                                        "{\"connectionString\":\"DefaultEndpointsProtocol=https;AccountName=dlsgroupdwhtest001;\",\"accountKey\":{\"type\":\"AzureKeyVaultSecret\",\"store\":" +
                                        "{\"referenceName\":\"ls_kv_groupdwh_test_001\",\"type\":\"LinkedServiceReference\"},\"secretName\":\"dlsgroupdwhtest001\"}}}}";

                var linkedService = AzureLinkedService
                    .As(AzureServiceType.AzureBlobStorage, "ls_dlsgroupdwhtest001", "Azure Blob Service dlsgroupdwhtest001")
                    .ConnectionString("DefaultEndpointsProtocol=https;AccountName=dlsgroupdwhtest001;")
                    .UsingSecret("dlsgroupdwhtest001")
                    .AccountKeyFromKeyVault("ls_kv_groupdwh_test_001")
                    .ToJson(JsonSerializer.MinifiedSettings)
                    .ToString();

            Console.WriteLine("Expected \n\n{0}\n",JsonSerializer.FormatJson(expectedData));

            Console.WriteLine("Actual \n\n{0}\n", JsonSerializer.FormatJson(linkedService));
           

            StringAssert.AreEqualIgnoringCase(expectedData, linkedService);

        }
    }
}
