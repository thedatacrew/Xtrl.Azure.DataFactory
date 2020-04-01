using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Xtrl.Azure.DataFactory.Fluent;

namespace Xtrl.Azure.DataFactory.UnitTests
{

    [SuppressMessage("ReSharper", "StringLiteralTypo")]

    [TestFixture]
    public class SqlServerLinkedServiceTests
    {

        [TestCase()]
        public void create_new_sql_server_linked_service_with_integration_runtime_and_key_vault_password()
        {

            const string expectedData =
                "{\"name\":\"ls_sqldb_groupdwh_test_001\",\"type\":\"Microsoft.DataFactory/factories/linkedservices\",\"properties\":{\"description\":\"Test SQL Service\",\"annotations\":[],\"type\":\"SqlServer\",\"typeProperties\":" +
                "{\"connectionString\":\"integrated Security=False;Encrypt=True;Connection Timeout=30;Data Source=mydbserver.database.windows.net;Initial Catalog=mydbname;User ID=mydbusername\",\"password\":" +
                "{\"type\":\"AzureKeyVaultSecret\",\"store\":{\"referenceName\":\"ls_kv_groupdwh_test_001\",\"type\":\"LinkedServiceReference\"},\"secretName\":\"TheDataCrewbi\"}},\"connectVia\":{\"referenceName\":\"df-ir-dev-hgbwm222-001\",\"type\":\"IntegrationRuntimeReference\"}}}";

            var linkedService = AzureLinkedService
                    .As(AzureServiceType.SqlServer, "ls_sqldb_groupdwh_test_001", "Test SQL Service")
                    .ConnectionString("integrated Security=False;Encrypt=True;Connection Timeout=30;Data Source=mydbserver.database.windows.net;Initial Catalog=mydbname;User ID=mydbusername")
                    .UsingSecret("TheDataCrewbi")
                    .PasswordFromKeyVault("ls_kv_groupdwh_test_001")
                    .ConnectVia("df-ir-dev-hgbwm222-001")
                    .ToJson(JsonSerializer.MinifiedSettings)
                    .ToString();


            Console.WriteLine("Expected \n\n{0}\n", JsonSerializer.FormatJson(expectedData));

            Console.WriteLine("Actual \n\n{0}\n", JsonSerializer.FormatJson(linkedService));

            StringAssert.AreEqualIgnoringCase(expectedData, linkedService);

        }

        [TestCase()]
        public void create_new_sql_server_linked_service_with_integration_runtime_and_encrypted_credentials()
        {

            const string expectedData =
                "{\"name\":\"ls_sqldb_groupdwh_test_001\",\"type\":\"Microsoft.DataFactory/factories/linkedservices\",\"properties\":{\"description\":\"Test SQL Service\",\"annotations\":[],\"type\":\"SqlServer\",\"typeProperties\":" +
                "{\"connectionString\":\"integrated Security=False;Encrypt=True;Connection Timeout=30;Data Source=mydbserver.database.windows.net;Initial Catalog=mydbname;User ID=mydbusername\",\"encryptedCredential\":\"my.encrypted.credentials\"},\"connectVia\":" +
                "{\"referenceName\":\"df-ir-dev-hgbwm222-001\",\"type\":\"IntegrationRuntimeReference\"}}}";

            var linkedService = AzureLinkedService
                .As(AzureServiceType.SqlServer, "ls_sqldb_groupdwh_test_001", "Test SQL Service")
                .ConnectionString("integrated Security=False;Encrypt=True;Connection Timeout=30;Data Source=mydbserver.database.windows.net;Initial Catalog=mydbname;User ID=mydbusername")
                .EncryptedCredentials("my.encrypted.credentials")
                .ConnectVia("df-ir-dev-hgbwm222-001")
                .ToJson(JsonSerializer.MinifiedSettings)
                .ToString();

            Console.WriteLine("Expected \n\n{0}\n", JsonSerializer.FormatJson(expectedData));

            Console.WriteLine("Actual \n\n{0}\n", JsonSerializer.FormatJson(linkedService));

            StringAssert.AreEqualIgnoringCase(expectedData, linkedService);
        }

        [TestCase()]
        public void create_new_sql_server_linked_service_with_encrypted_credentials()
        {

            const string expectedData =
                "{\"name\":\"ls_sqldb_groupdwh_test_001\",\"type\":\"Microsoft.DataFactory/factories/linkedservices\",\"properties\":{\"description\":\"Test SQL Service\",\"annotations\":[],\"type\":\"SqlServer\",\"typeProperties\":" +
                "{\"connectionString\":\"integrated Security=False;Encrypt=True;Connection Timeout=30;Data Source=mydbserver.database.windows.net;Initial Catalog=mydbname;User ID=mydbusername\",\"encryptedCredential\":\"my.encrypted.credentials\"}}}";

            var linkedService = AzureLinkedService
                .As(AzureServiceType.SqlServer, "ls_sqldb_groupdwh_test_001", "Test SQL Service")
                .ConnectionString("integrated Security=False;Encrypt=True;Connection Timeout=30;Data Source=mydbserver.database.windows.net;Initial Catalog=mydbname;User ID=mydbusername")
                .EncryptedCredentials("my.encrypted.credentials")
                .ToJson(JsonSerializer.MinifiedSettings)
                .ToString();

            Console.WriteLine("Expected \n\n{0}\n", JsonSerializer.FormatJson(expectedData));

            Console.WriteLine("Actual \n\n{0}\n", JsonSerializer.FormatJson(linkedService));

            StringAssert.AreEqualIgnoringCase(expectedData, linkedService);

        }
    }
}
