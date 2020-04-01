using System;
using System.IO;
using Newtonsoft.Json;
using Xtrl.Azure.DataFactory.Fluent.Interface;
using Xtrl.Azure.DataFactory.Models;

namespace Xtrl.Azure.DataFactory.Fluent
{
    //  ReSharper disable CommentTypo
    /// <summary>
    ///     AzureDataSet("CognosCH_Customer_1_Src","ls_dlsgroupdwhtest001")
    ///         .As("DelimitedText")
    ///         .WithTextSettings(columnDelimiter:"\t",rowDelimiter:"\n",encodingName: "UTF-16",escapeChar: "\"",firstRowAsHeader: true, quoteChar : "\"")
    ///         .AtLocation("AzureBlobStorage","CognosCH",  container: "incoming")
    ///         .WithSchema()
    ///         .Add("CustomerBK","String")
    ///         .Add("AC","String")
    /// </summary>
    public sealed class AzureDataSet :
        IAzureLinkedService,
        IAzureLinkedServiceConnectionInfo,
        IAzureLinkedServiceCredentials,
        IAzureLinkedServiceKeyVaultSecret,
        IAzureLinkedServiceIntegrationRuntime,
        IAzureSerializeAction,
        IAzureWrite
    {

        private readonly string _name;
        private readonly string _propertyDescription;
        // private readonly string _linkedServiceDescription;
        private readonly AzureServiceType _azureServiceType;

        private string _connectionString;
        private string _encryptedCredentials;
        private string _integrationRuntimeReference;
        private string _filePath;
        private string _baseUrl;
        private string _keyVaultReferenceName;
        private string _keyVaultSecretName;
        private string _jsonData;

        private PasswordModel _passwordModel;
        private ConnectViaModel _connectViaModel;
        private AccountKeyModel _accountKeyModel;

        #region ctor

        private AzureDataSet(AzureServiceType azureServiceType, string name, string description)
        {
            _azureServiceType = azureServiceType;
            _name = name;

            // AzureKeyVault does not store the description in the same JSON
            // node as the other linked services do.
            //
            //if (_azureServiceType == AzureServiceType.AzureKeyVault)
            //    _propertyDescription = description;
            //else
            //    _linkedServiceDescription = description;
            _propertyDescription = description;
        }

        #endregion

        #region Private Methods


        #endregion

        #region Public Static Methods

        public static IAzureLinkedService As(AzureServiceType type, string name, string description) => new AzureDataSet(type, name, description);

        #endregion

        #region Interface Implementation

        public AzureLinkedServiceModel GetAzureLinkedService()
        {
            var myLinkedService = new AzureLinkedServiceModel
            {
                Name = _name,
                Type = "Microsoft.DataFactory/factories/linkedservices",
                Properties = new PropertiesModel
                {
                    PropertyDescription = _propertyDescription,
                    Type = _azureServiceType.ToString(),

                    TypeProperties = new TypePropertiesModel
                    {
                        ConnectionString = _connectionString,
                        EncryptedCredential = _encryptedCredentials,
                        BaseUrl = _baseUrl,
                        Password = _passwordModel,
                        AccountKey = _accountKeyModel

                    },
                    Annotations = new string[] { },
                    ConnectVia = _connectViaModel
                },

                //LinkedServiceDescription = _linkedServiceDescription
            };
            return myLinkedService;
        }

        public IAzureLinkedServiceCredentials ConnectionString(string connectionString)
        {
            _connectionString = connectionString;
            return this;
        }

        public IAzureLinkedServiceIntegrationRuntime EncryptedCredentials(string encryptedCredentials)
        {
            _encryptedCredentials = encryptedCredentials;
            return this;
        }

        public IAzureWrite ToJson()
        {
            _jsonData = GetAzureLinkedService().ToJsonString();
            return this;
        }

        public IAzureWrite ToJson(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonData = GetAzureLinkedService().ToJsonString(jsonSerializerSettings);
            return this;
        }

        public void ToFile(string filePath)
        {
            _filePath = filePath;

            var jsonData = GetAzureLinkedService().ToJsonString();
            File.WriteAllText(_filePath, jsonData);
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(_jsonData))
                return _jsonData;

            throw new NotImplementedException();
        }

        public IAzureSerializeAction BaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl;
            return this;
        }

        public IAzureSerializeAction ConnectVia(string integrationRuntimeReference)
        {
            _integrationRuntimeReference = integrationRuntimeReference;

            _connectViaModel = new ConnectViaModel
            { Type = "IntegrationRuntimeReference", ReferenceName = _integrationRuntimeReference };

            return this;
        }

        public IAzureLinkedServiceKeyVaultSecret UsingSecret(string keyVaultSecretName)
        {
            _keyVaultSecretName = keyVaultSecretName;

            if (_passwordModel != null) _passwordModel.SecretName = _keyVaultSecretName;
            if (_accountKeyModel != null) _accountKeyModel.SecretName = _keyVaultSecretName;

            return this;
        }

        public IAzureLinkedServiceIntegrationRuntime PasswordFromKeyVault(string keyVaultReferenceName)
        {
            _keyVaultReferenceName = keyVaultReferenceName;

            _passwordModel = new PasswordModel
            {

                SecretName = _keyVaultSecretName,
                Store = new StoreModel { Type = "LinkedServiceReference", ReferenceName = _keyVaultReferenceName },
                Type = "AzureKeyVaultSecret"

            };

            return this;
        }


        public IAzureLinkedServiceIntegrationRuntime AccountKeyFromKeyVault(string keyVaultReferenceName)
        {
            _keyVaultReferenceName = keyVaultReferenceName;

            _accountKeyModel = new AccountKeyModel()
            {
                SecretName = _keyVaultSecretName,
                Type = "AzureKeyVaultSecret",
                Store = new StoreModel { Type = "LinkedServiceReference", ReferenceName = _keyVaultReferenceName }
            };

            return this;
        }



        #endregion
    }
}