using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Xtrl.Azure.DataFactory.Fluent;

namespace Xtrl.Azure.DataFactory.UnitTests
{

    [SuppressMessage("ReSharper", "StringLiteralTypo")]

    [TestFixture]
    public class AzureKeyVaultLinkedServiceTests
    {

        [TestCase()]
        public void create_new_azure_key_vault_linked_service_using_key_vault_to_store_account_key()
        {

            const string expectedData =
                "{\"name\":\"ls_kv_groupdwh_test_001\",\"type\":\"Microsoft.DataFactory/factories/linkedservices\",\"properties\":{\"description\":\"Azure Key Vault kv-groupdwh-test-001\",\"annotations\":[],\"type\":\"AzureKeyVault\",\"typeProperties\":{\"baseUrl\":\"https://kv-groupdwh-test-001.vault.azure.net/\"}}}";

            var linkedService = AzureLinkedService
                .As(AzureServiceType.AzureKeyVault, "ls_kv_groupdwh_test_001", "Azure Key Vault kv-groupdwh-test-001")
                .BaseUrl("https://kv-groupdwh-test-001.vault.azure.net/")
                .ToJson(JsonSerializer.MinifiedSettings)
                .ToString();

            Console.WriteLine("Expected \n\n{0}\n", JsonSerializer.FormatJson(expectedData));

            Console.WriteLine("Actual \n\n{0}\n", JsonSerializer.FormatJson(linkedService));

            StringAssert.AreEqualIgnoringCase(expectedData, linkedService);

        }
    }
}
