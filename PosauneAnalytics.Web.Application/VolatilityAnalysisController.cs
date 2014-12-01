using PosauneAnalytics.FileManager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace PosauneAnalytics.Web.Application
{
    public class VolatilityAnalysisController : IVolatilityAnalysisController
    {
        private IDownloadService _downloadService;
        private Dictionary<DateTime, string> _fileCollection;

        public DateTime MinDate { get { return _fileCollection.Keys.Min(); } }
        public DateTime MaxDate { get { return _fileCollection.Keys.Max(); } }

        public VolatilityAnalysisController()
        {
            Initialize();
        }

        private void Initialize()
        {
            _fileCollection = new Dictionary<DateTime, string>();
            _downloadService = new DownloadService();

            var downloadedFiles = _downloadService.GetDownloadedFiles();
            string pattern = "yyyyMMdd";

            foreach (string name in downloadedFiles)
            {
                string[] data = name.Split(new char[] { '.' });
                DateTime date;
                if (DateTime.TryParseExact(data[2], pattern, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                {
                    _fileCollection.Add(date, name);
                }
            }
        }

        public List<SeriesData> Run(DateTime date)
        {
            var seriesData = new List<SeriesData>();

            var fileName = FindFilename(date);

            IBlobManager blobmanager = new BlobManager();
            MemoryStream ms = blobmanager.Download(fileName);

            IZipUtils zipUtils = new ZipUtils();
            string xml = zipUtils.UnZip(ms, fileName);

            ICmeFileParser parser = new CmeFileParser();

            var seriesInfoList = parser.Parse(xml);

            foreach (SeriesInfo si in seriesInfoList.Values)
            {
                var table = new VolatilityAnalysisModel.SeriesBaseDataTable();

                foreach(var opt in si.Options)
                {
                    VolatilityAnalysisModel.SeriesBaseRow row = table.AsEnumerable().FirstOrDefault(r => r.StrikePrice == opt.StrikePrice);
                    if (row == null)
                    {
                        if (opt.SecurityType == SecurityType.Call)
                        {
                            table.AddSeriesBaseRow(opt.StrikePrice, opt.TickPrice, String.Empty, String.Empty, String.Empty);
                        }
                        else
                        {
                            table.AddSeriesBaseRow(opt.StrikePrice, String.Empty, opt.TickPrice, String.Empty, String.Empty);
                        }
                    }
                    else
                    {
                        if (opt.SecurityType == SecurityType.Call)
                        {
                            row.SettlePriceCall = opt.TickPrice;
                        }
                        else
                        {
                            row.SettlePricePut = opt.TickPrice;
                        }
                    }
                }

                table.DefaultView.RowFilter = String.Format("StrikePrice > {0} - 6 and StrikePrice < {0} + 6", si.Underlying.Price);

                seriesData.Add(new SeriesData()
                {
                    SeriesName = si.ExpirationMonth,
                    Underlying = si.Underlying.Description,
                    Price = si.Underlying.TickPrice,
                    Symbol = si.Underlying.Symbol,
                    Model = table
                });
            }

            return seriesData;
        }

        private string FindFilename(DateTime date)
        {
            if (_fileCollection.ContainsKey(date))
            {
                return _fileCollection[date];
            }

            List<DateTime> dates = new List<DateTime>(_fileCollection.Keys);


            DateTime closest = dates.FirstOrDefault(d => d > date);

            if (closest == default(DateTime))
            {
                closest = dates.First();
            }

            return _fileCollection[closest];

        }

    }

    public class SeriesData
    {
        public string SeriesName { get; set; }
        public string Underlying { get; set; }
        public string Price { get; set; }
        public string Symbol { get; set; }
        public VolatilityAnalysisModel.SeriesBaseDataTable Model { get; set; }
    }
}