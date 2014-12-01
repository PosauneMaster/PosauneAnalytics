using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public interface IBlobManager
    {
        bool Upload(MemoryStream stream, string fileName);
        List<string> GetBlobs();
        MemoryStream Download(string blobName);

    }
}
