using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class VolatilityService
    {
        private IBlobManager _blobmanager;
        private ICmeFileParser _cmeFileParser;

        public VolatilityService()
        {
            _blobmanager = new BlobManager();
            _cmeFileParser = new CmeFileParser();
        }

        public void CreateVolatilityInfo(string filename)
        {
            MemoryStream ms =_blobmanager.Download(filename);
            var info =  _cmeFileParser.Parse(ms, filename);
        }
    }
}
