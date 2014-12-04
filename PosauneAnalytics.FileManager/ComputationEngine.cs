using PosauneAnalytics.Libraries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class ComputationEngine : IComputationEngine
    {
        private ImpliedVolatility _impliedVol;
        private BlackScholes _blackScholes;


        public double RiskFreeRate { get; set; }
        public double DaysToExpiration { get; set; }

        public ComputationEngine()
        {
            _impliedVol = new ImpliedVolatility();
            _blackScholes = new BlackScholes();
            SetRiskFreeRate();
        }

        private void SetRiskFreeRate()
        {
            string rate = ConfigurationManager.AppSettings["riskFreeRate"];
            double r;
            if (Double.TryParse(rate, out r))
            {
                RiskFreeRate = r;
            }
            else
            {
                RiskFreeRate = 0.01;
            }
        }

        public void ComputeImplied(OptionSettlement option)
        {
            OptionDataObject optionDataObject = new OptionDataObject()
            {
                AssetPrice = option.Underlying.DollarPrice * 1000,
                Strike = option.StrikePrice * 1000,
                TimeToMaturity = CalcDaysToExpiration(option),
                RiskFreeRate = RiskFreeRate,
                CostOfCarry = 0.00d,
                PutCall = option.SecurityType
            };

            option.ImpliedVolatility = _impliedVol.Bisect(optionDataObject, option.DollarPrice * 1000);
            option.Delta = _blackScholes.GDelta(
                optionDataObject.PutCall, optionDataObject.Strike, optionDataObject.AssetPrice, optionDataObject.TimeToMaturity, optionDataObject.RiskFreeRate, optionDataObject.CostOfCarry, option.ImpliedVolatility);
        }

        private double CalcDaysToExpiration(OptionSettlement option)
        {
            DateTime settlementDate = option.BusinessDate;
            DateTime expirationDate = option.MaturityDate.AddDays(1);

            DaysToExpiration = (expirationDate - settlementDate).TotalDays;

            return ((double)(expirationDate - settlementDate).TotalDays) / 360;

        }

        public void ComputeSeriesAnalysis(IEnumerable<SeriesInfo> seriesInfo)
        {
            foreach (var si in seriesInfo)
            {
                var seriesDictionary = new Dictionary<Double, OptionSeries>();
                foreach (var opt in si.Options)
                {
                    ComputeImplied(opt);
                    si.RiskFreeRate = RiskFreeRate;
                    si.DaysToExpiration = (int)DaysToExpiration;

                    if (!seriesDictionary.ContainsKey(opt.StrikePrice))
                    {
                        seriesDictionary.Add(opt.StrikePrice, new OptionSeries());
                    }

                    OptionSeries series = seriesDictionary[opt.StrikePrice];
                    series.AddOption(opt);
                }

                si.Regression = ComputeSkew(seriesDictionary.Values);
                si.AddOptionSeries(seriesDictionary.Values);
            }
        }

        public PolynominalRegression ComputeSkew(IEnumerable<OptionSeries> series)
        {
            var optionSeriesList = new List<OptionSeries>();

            foreach(var opt in series)
            {
                if (opt.Call.DollarPrice * 1000 > 15.625 && opt.Put.DollarPrice * 1000 > 15.625)
                {
                    optionSeriesList.Add(opt);
                }
            }

            var x_data = new List<double>();
            var y_data = new List<double>();

            foreach (var o in optionSeriesList)
            {
                y_data.Add(o.SeriesBaseImpliedVolatility);
                x_data.Add(o.Call.StrikePrice);
            }

            var poly = new PolynominalRegression(x_data, y_data);

            foreach (var o in optionSeriesList)
            {
                o.TheoImpliedVolatility = poly.Calculate(o.Call.StrikePrice);

                double underlyingPrice = o.Call.Underlying.DollarPrice * 1000;
                double strikePrice = o.Call.StrikePrice * 1000;
                double timeToMaturity = CalcDaysToExpiration(o.Call);

                o.SetCallPrice(_blackScholes.GBlackScholesPrice(
                    SecurityType.Call, underlyingPrice, strikePrice, timeToMaturity, RiskFreeRate, 0.00d, o.SeriesBaseImpliedVolatility));

                o.SetPutPrice(_blackScholes.GBlackScholesPrice(
                    SecurityType.Put, underlyingPrice, strikePrice, timeToMaturity, RiskFreeRate, 0.00d, o.SeriesBaseImpliedVolatility));

            }

            return poly;

        }
    }

    public class OptionSeries
    {
        public OptionSettlement Call { get; set; }
        public OptionSettlement Put { get; set; }
        public Settlement Underlying { get; set; }
        public double StrikePrice
        {
            get { return Call.StrikePrice; }
        }
        public double SeriesBaseImpliedVolatility { get; set; }
        public double TheoImpliedVolatility { get; set; }
        public double TheoCallDollar { get; private set; }
        public double TheoPutDollar { get; private set; }
        public string TheoCall { get; private set; }
        public string TheoPut { get; private set; }


        public void SetPutPrice(double price)
        {
            TheoPutDollar = price;
            TheoPut = GetPriceString(price);
        }

        public void SetCallPrice(double price)
        {
            TheoCallDollar = price;
            TheoCall = GetPriceString(price);
        }

        private string GetPriceString(double price)
        {
            double handle = (Int32)(Math.Max(0, Math.Truncate(Math.Truncate(price / 15.625) / 64)));
            double ticks = Math.Truncate((price - (handle * 64 * 15.625)) / 15.625);
            double fraction = (price - ((handle * 64 * 15.625) + (ticks * 15.625)))/15.625;

            return String.Format("{0:N0} {1:N0} {2:N2}", handle, ticks, fraction);
        }

        public void AddOption(OptionSettlement option)
        {
            if (option.SecurityType == SecurityType.Call)
            {
                Call = option;
            }

            if (option.SecurityType == SecurityType.Put)
            {
                Put = option;
            }

            if (Call != null && Put != null)
            {
                double putWeight = (1 - Math.Abs(Put.Delta)) * Put.ImpliedVolatility;
                double callWeight = (1 - Math.Abs(Call.Delta)) * Call.ImpliedVolatility;
                SeriesBaseImpliedVolatility = putWeight + callWeight;
            }
        }
    }
}
