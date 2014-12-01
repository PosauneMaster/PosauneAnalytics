using System.IO;

namespace PosauneAnalytics.FileManager
{
    public interface IZipUtils
    {
        string UnZip(MemoryStream stream, string fileName);
    }
}
