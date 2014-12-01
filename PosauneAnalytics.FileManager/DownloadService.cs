using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class DownloadService : IDownloadService
    {
        private IBlobManager _blobManager;
        private ICmeDownloader _cmeDownloader;

        public DownloadService()
        {
            _blobManager = new BlobManager();
            _cmeDownloader = new CmeDownloader();
        }

        public void DownloadSelected(IEnumerable<string> filenames)
        {
            foreach (var file in filenames)
            {
                var downloaded = _cmeDownloader.Download(file);
                _blobManager.Upload(downloaded.FileStream, downloaded.FileName);
            }
        }

        public List<string> GetDownloadedFiles()
        {
            return _blobManager.GetBlobs();
        }

        public List<CmeFileDetails> ListFtpDirectoryDetails()
        {
            return _cmeDownloader.ListDirectoryDetails();
        }
    }
}
