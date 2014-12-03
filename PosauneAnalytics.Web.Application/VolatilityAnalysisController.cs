using PosauneAnalytics.FileManager;
using PosauneAnalytics.Libraries;
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
        private IFileMapper _fileMapper;
        private IComputationEngine _engine;

        private Dictionary<DateTime, string> _fileCollection;

        public DateTime MinDate { get { return _fileCollection.Keys.Min(); } }
        public DateTime MaxDate { get { return _fileCollection.Keys.Max(); } }

        public VolatilityAnalysisController()
        {
            _downloadService = new DownloadService();
            _fileMapper = new FileMapper();
            _engine = new ComputationEngine();
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

            var seriesInfoList = _fileMapper.MapToSeries(fileName);
            
            foreach (SeriesInfo si in seriesInfoList.Values)
            {
                var table = new VolatilityAnalysisModel.SeriesBaseDataTable();

                CreateRows(si, table);

                SetRowVisibility(table);

                seriesData.Add(new SeriesData()
                {
                    SeriesName = si.ExpirationMonth,
                    Underlying = si.Underlying.Description,
                    Price = si.Underlying.TickPrice,
                    Symbol = si.Underlying.Symbol,
                    ExpirationDate = si.ExpirationDate.ToString("MM/dd/yyyy"),
                    RiskFreeRate = si.RiskFreeRate.ToString("P2"),
                    DaysToExpiration = si.DaysToExpiration.ToString("G"),
                    Model = table
                });
            }

            return seriesData;
        }


        private void SetRowVisibility(VolatilityAnalysisModel.SeriesBaseDataTable table)
        {
            var visibleRows = from row in table.AsEnumerable<VolatilityAnalysisModel.SeriesBaseRow>()
                              where row.DollarSettleCall > 15.625 && row.DollarSettlePut > 15.625
                              select row;


            foreach (VolatilityAnalysisModel.SeriesBaseRow row in visibleRows)
            {
                row.Visible = true;
            }

            var putRows = from row in table.AsEnumerable<VolatilityAnalysisModel.SeriesBaseRow>()
                          orderby row.SettlePricePut descending
                          select row;

            var pr = putRows.Last(r => r.DollarSettlePut == 15.625);
            pr.Visible = true;

            var cr = putRows.First(r => r.DollarSettleCall == 15.625);
            cr.Visible = true;

            table.DefaultView.RowFilter = "Visible = true";
        }

        private void CreateRows(SeriesInfo si, VolatilityAnalysisModel.SeriesBaseDataTable table)
        {
            foreach (var opt in si.Options)
            {
                _engine.ComputeImplied(opt);
                si.RiskFreeRate = _engine.RiskFreeRate;
                si.DaysToExpiration = (int)_engine.DaysToExpiration;

                VolatilityAnalysisModel.SeriesBaseRow row = table.AsEnumerable().FirstOrDefault(r => r.StrikePrice == opt.StrikePrice);
                if (row == null)
                {
                    if (opt.SecurityType == SecurityType.Call)
                    {
                        table.AddSeriesBaseRow(opt.StrikePrice, opt.TickPrice, String.Empty, opt.ImpliedVolatilityDisplay, String.Empty, false, opt.DollarPrice * 1000, 0.00d);
                    }
                    else
                    {
                        table.AddSeriesBaseRow(opt.StrikePrice, String.Empty, opt.TickPrice, String.Empty, opt.ImpliedVolatilityDisplay, false, 0.00d, opt.DollarPrice * 1000);
                    }
                }
                else
                {
                    if (opt.SecurityType == SecurityType.Call)
                    {
                        row.SettlePriceCall = opt.TickPrice;
                        row.DollarSettleCall = opt.DollarPrice * 1000;
                        row.ImpliedVolCall = opt.ImpliedVolatilityDisplay;
                        row.Visible = false;
                    }
                    else
                    {
                        row.SettlePricePut = opt.TickPrice;
                        row.DollarSettlePut = opt.DollarPrice * 1000;
                        row.ImpliedVolPut = opt.ImpliedVolatilityDisplay;
                        row.Visible = false;
                    }
                }
            }
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
        public string ExpirationDate { get; set; }
        public string RiskFreeRate { get; set; }
        public string DaysToExpiration { get; set; }
        public VolatilityAnalysisModel.SeriesBaseDataTable Model { get; set; }
    }
}