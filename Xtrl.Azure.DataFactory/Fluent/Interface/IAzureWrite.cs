namespace Xtrl.Azure.DataFactory.Fluent.Interface
{
    public interface IAzureWrite
    {
        void ToFile(string filePath);
        string ToString();

    }
}