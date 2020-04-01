using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Xtrl.Azure.DataFactory.Fluent;

namespace Xtrl.Azure.DataFactory.UnitTests
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]

    [TestFixture]
    public class AzurePipelineTest
    {

        [TestCase()]
        public void create_new_pipeline_with_2_execution_pipeline_activities()
        {

            const string expectedData = "{\"name\":\"ETL TheDataCrew MDM to EDW Master - Level 1\",\"properties\":{\"description\":\"TheDataCrew Master Data ETL to Data Warehouse\",\"activities\":[{\"name\":\"TheDataCrew MDM to EDW TheDataCrew_City\",\"type\":\"ExecutePipeline\",\"dependsOn\":[],\"userProperties\":[],\"typeProperties\":{\"pipeline\":" +
                                        "{\"referenceName\":\"copy_data_sql_server_to_sql_server\",\"type\":\"PipelineReference\"},\"waitOnCompletion\":true,\"parameters\":{\"p_tableMappingID\":\"3\",\"p_packageID\":\"3\"}}},{\"name\":\"TheDataCrew MDM to EDW TheDataCrew_Currency\",\"type\":\"ExecutePipeline\",\"dependsOn\":[],\"userProperties\":[],\"typeProperties\":{\"pipeline\":" +
                                        "{\"referenceName\":\"copy_data_sql_server_to_sql_server\",\"type\":\"PipelineReference\"},\"waitOnCompletion\":true,\"parameters\":{\"p_tableMappingID\":\"4\",\"p_packageID\":\"4\"}}}],\"folder\":{\"name\":\"ETL/Master Packages/MDM\"},\"annotations\":[]},\"type\":\"Microsoft.DataFactory/factories/pipelines\"}";
            
            var azurePipeline = AzurePipeline
                .As("ETL TheDataCrew MDM to EDW Master - Level 1", "TheDataCrew Master Data ETL to Data Warehouse", "ETL/Master Packages/MDM")
                .AddExecutePipeline("TheDataCrew MDM to EDW TheDataCrew_City", "copy_data_sql_server_to_sql_server", "p_tableMappingID:3,p_packageID:3")
                .AddExecutePipeline("TheDataCrew MDM to EDW TheDataCrew_Currency", "copy_data_sql_server_to_sql_server", "p_tableMappingID:4,p_packageID:4")
                .ToJson(JsonSerializer.MinifiedSettings)
                .ToString();

            Console.WriteLine("Expected \n\n{0}\n", JsonSerializer.FormatJson(expectedData));

            Console.WriteLine("Actual \n\n{0}\n", JsonSerializer.FormatJson(azurePipeline));

            StringAssert.AreEqualIgnoringCase(azurePipeline, expectedData);

        }

        [TestCase()]
        public void create_new_pipeline_with_5_dynamically_created_execution_pipeline_activities()
        {

            const string expectedData =
                "{\"name\":\"ETL TheDataCrew MDM to EDW Master - Level 1\",\"properties\":{\"description\":\"TheDataCrew Master Data ETL to Data Warehouse\",\"activities\":[{\"name\":\"TheDataCrew MDM to EDW TheDataCrew_City\",\"type\":\"ExecutePipeline\",\"dependsOn\":[],\"userProperties\":[],\"typeProperties\":{\"pipeline\":" +
                "{\"referenceName\":\"copy_data_sql_server_to_sql_server\",\"type\":\"PipelineReference\"},\"waitOnCompletion\":true,\"parameters\":{\"p_tableMappingID\":\"0\",\"p_packageID\":\"0\"}}},{\"name\":\"TheDataCrew MDM to EDW TheDataCrew_City\",\"type\":\"ExecutePipeline\",\"dependsOn\":[],\"userProperties\":[],\"typeProperties\":{\"pipeline\":" +
                "{\"referenceName\":\"copy_data_sql_server_to_sql_server\",\"type\":\"PipelineReference\"},\"waitOnCompletion\":true,\"parameters\":{\"p_tableMappingID\":\"1\",\"p_packageID\":\"1\"}}},{\"name\":\"TheDataCrew MDM to EDW TheDataCrew_City\",\"type\":\"ExecutePipeline\",\"dependsOn\":[],\"userProperties\":[],\"typeProperties\":{\"pipeline\":" +
                "{\"referenceName\":\"copy_data_sql_server_to_sql_server\",\"type\":\"PipelineReference\"},\"waitOnCompletion\":true,\"parameters\":{\"p_tableMappingID\":\"2\",\"p_packageID\":\"2\"}}},{\"name\":\"TheDataCrew MDM to EDW TheDataCrew_City\",\"type\":\"ExecutePipeline\",\"dependsOn\":[],\"userProperties\":[],\"typeProperties\":{\"pipeline\":" +
                "{\"referenceName\":\"copy_data_sql_server_to_sql_server\",\"type\":\"PipelineReference\"},\"waitOnCompletion\":true,\"parameters\":{\"p_tableMappingID\":\"3\",\"p_packageID\":\"3\"}}},{\"name\":\"TheDataCrew MDM to EDW TheDataCrew_City\",\"type\":\"ExecutePipeline\",\"dependsOn\":[],\"userProperties\":[],\"typeProperties\":{\"pipeline\":" +
                "{\"referenceName\":\"copy_data_sql_server_to_sql_server\",\"type\":\"PipelineReference\"},\"waitOnCompletion\":true,\"parameters\":{\"p_tableMappingID\":\"4\",\"p_packageID\":\"4\"}}}],\"folder\":{\"name\":\"ETL/Master Packages/MDM\"},\"annotations\":[]},\"type\":\"Microsoft.DataFactory/factories/pipelines\"}";

            var azurePipeline = AzurePipeline.As("ETL TheDataCrew MDM to EDW Master - Level 1", "TheDataCrew Master Data ETL to Data Warehouse", "ETL/Master Packages/MDM");

            for (int i = 0; i < 5; i++)
            {
                azurePipeline.AddExecutePipeline("TheDataCrew MDM to EDW TheDataCrew_City", "copy_data_sql_server_to_sql_server", $"p_tableMappingID:{i},p_packageID:{i}");
            }

            var jsonString = azurePipeline.ToJsonString(JsonSerializer.MinifiedSettings);

            Console.WriteLine("Expected \n\n{0}\n", JsonSerializer.FormatJson(expectedData));

            Console.WriteLine("Actual \n\n{0}\n", JsonSerializer.FormatJson(jsonString));

            StringAssert.AreEqualIgnoringCase(expectedData, jsonString);

        }

    }

}
