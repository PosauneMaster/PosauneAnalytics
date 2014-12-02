using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public interface IDownloadService
    {
        void DownloadSelected(IEnumerable<string> filenames);
        List<string> GetDownloadedFiles();
        List<CmeFileDetails> ListFtpDirectoryDetails();
    }
}
