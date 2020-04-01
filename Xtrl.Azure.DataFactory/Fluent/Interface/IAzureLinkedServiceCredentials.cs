namespace Xtrl.Azure.DataFactory.Fluent.Interface
{
    public interface IAzureLinkedServiceCredentials
    {
        IAzureLinkedServiceIntegrationRuntime EncryptedCredentials(string encryptedCredentials);
        IAzureLinkedServiceKeyVaultSecret UsingSecret(string keyVaultSecretName);

    }

    public interface IAzureLinkedServiceKeyVaultSecret
    {

        IAzureLinkedServiceIntegrationRuntime PasswordFromKeyVault(string keyVaultReferenceName);
        IAzureLinkedServiceIntegrationRuntime AccountKeyFromKeyVault(string keyVaultReferenceName);
    }

}