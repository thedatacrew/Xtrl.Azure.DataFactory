using System.IO;

namespace Xtrl.Azure.DataFactory.Fluent.Interface
{
    public interface IAzureRead
    {
        void FromFile(string filePath);
        void FromStream(Stream stream);
    }
}