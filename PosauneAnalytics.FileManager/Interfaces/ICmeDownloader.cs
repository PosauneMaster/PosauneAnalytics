using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public interface ICmeDownloader
    {
        SettlementDownload Download(string filename);
        SettlementDownload Download(DateTime date);
        List<CmeFileDetails> ListDirectoryDetails();
    }
}
