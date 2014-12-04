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
        public double RiskFreeRate { get; set; }
        public double DaysToExpiration { get; set; }

        public ComputationEngine()
        {
            _impliedVol = new ImpliedVolatility();
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
        }

        private double CalcDaysToExpiration(OptionSettlement option)
        {
            DateTime settlementDate = option.BusinessDate;
            DateTime expirationDate = option.MaturityDate.AddDays(1);

            DaysToExpiration = (expirationDate - settlementDate).TotalDays;

            return ((double)(expirationDate - settlementDate).TotalDays) / 360;

        }
    }
}
