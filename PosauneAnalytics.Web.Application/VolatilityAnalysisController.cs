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
        public string Username { get; set; }

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

        private Dictionary<DateTime, SeriesInfo> CreateWeightedSeries(Dictionary<DateTime, SeriesInfo> seriesList, Dictionary<DateTime, double> weights)
        {

            var weighted = new Dictionary<DateTime, SeriesInfo>();
            foreach (var kvp in seriesList)
            {
                var info = SeriesInfo.DeepCopy(kvp.Value);
                info.SetParent(info.SeriesId);
                info.TimeToExpiration = weights[kvp.Key];
                weighted.Add(kvp.Key, info);
            }

            return weighted;
        }

        public List<SeriesData> Run(DateTime date, string profilename)
        {
            ICalendarService service = new CalendarService()
            {
                Username = Username,
                Profilename = profilename
            };

            var seriesData = new List<SeriesData>();

            var fileName = FindFilename(date);

            var seriesInfoList = _fileMapper.MapToSeries(fileName);
            var weights = service.ComputeAdjustments(date, seriesInfoList.Keys);
            var weightedSeriesList = CreateWeightedSeries(seriesInfoList, weights);

            var seriesLookUp = _engine.ComputeSeriesAnalysis(seriesInfoList.Values);
            _engine.ComputeSeriesAnalysisWeighted(weightedSeriesList.Values);

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
                    //WeightedDaysToExpiration = si.WeightedDays.ToString("G"),
                    Polynomial = si.Regression.LeastSquaresFit(),
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
            foreach(OptionSeries series in si.Series)
            {
                VolatilityAnalysisModel.SeriesBaseRow row = table.NewSeriesBaseRow();
                row = table.NewSeriesBaseRow();
                row.StrikePrice = series.StrikePrice;
                row.SettlePriceCall = series.Call.TickPrice;
                row.SettlePricePut = series.Put.TickPrice;
                row.ImpliedVolCall = series.Call.ImpliedVolatilityDisplay;
                row.ImpliedVolPut = series.Put.ImpliedVolatilityDisplay;
                row.Visible = false;
                row.DollarSettleCall = series.Call.DollarPrice * 1000;
                row.DollarSettlePut = series.Put.DollarPrice * 1000;
                row.CallDelta = series.Call.Delta;
                row.PutDelta = series.Put.Delta;
                row.SeriesBaseVol = series.SeriesBaseImpliedVolatility;
                row.TheoCallDollar = series.TheoCallDollar;
                row.TheoPutDollar = series.TheoPutDollar;
                row.TheoCall = series.TheoCall;
                row.TheoPut = series.TheoPut;

                table.Rows.Add(row);
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
        public string WeightedDaysToExpiration { get; set; }
        public string Polynomial { get; set; }
        public VolatilityAnalysisModel.SeriesBaseDataTable Model { get; set; }
    }
}