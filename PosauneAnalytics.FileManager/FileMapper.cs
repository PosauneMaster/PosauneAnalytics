using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class FileMapper : IFileMapper
    {
        private IBlobManager _blobmanager;
        private IZipUtils _zipUtils;
        private ICmeFileParser _parser;

        public FileMapper()
        {
            _blobmanager = new BlobManager();
            _zipUtils = new ZipUtils();
            _parser = new CmeFileParser();
        }

        public FileMapper(IBlobManager blobmanager, IZipUtils zipUtils, ICmeFileParser parser)
        {
            _blobmanager = blobmanager;
            _zipUtils = zipUtils;
            _parser = parser;
        }

        public Dictionary<DateTime, SeriesInfo> MapToSeries(string fileName)
        {
            IBlobManager blobmanager = new BlobManager();
            MemoryStream ms = blobmanager.Download(fileName);

            IZipUtils zipUtils = new ZipUtils();
            string xml = zipUtils.UnZip(ms, fileName);

            ICmeFileParser parser = new CmeFileParser();

            var seriesInfoList = parser.Parse(xml);
            return seriesInfoList;

        }

    }
}
