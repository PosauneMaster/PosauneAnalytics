using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class SeriesInfo
    {
        public Settlement Underlying { get; set; }
        public List<OptionSettlement> Options { get; set; }

        public string ExpirationMonth { get; set; }

        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                _expirationDate = value;
                SetExpiration(value);

            }
        }

        public double RiskFreeRate { get; set; }
        public string Description { get; set; }

        public SeriesInfo()
        {
            Options = new List<OptionSettlement>();
        }

        public void AddOption(OptionSettlement os)
        {
            Options.Add(os);
        }

        private void SetExpiration(DateTime dt)
        {
            DateTime seriesDate = dt.AddMonths(1);
            ExpirationMonth = String.Format("{0} {1}", seriesDate.ToShortMonthName(), seriesDate.Year);
        }

        public string GetSeriesString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Underlying, Underlying Price, Maturity Date, Expiration, Business Date, Security Type, Strike Price, Price");

            foreach (var settlement in Options)
            {
                var list = new List<string>();
                list.Add(Underlying.MonthYear);
                list.Add(Underlying.Price);
                list.Add(settlement.MaturityDate.ToString("yyyyMMdd"));
                list.Add(ExpirationMonth);
                list.Add(settlement.BusinessDate.ToString("yyyyMMdd"));
                list.Add(settlement.SecurityType.ToString());
                list.Add(settlement.StrikePrice.ToString());
                list.Add(settlement.Price);
                sb.AppendLine(String.Join(",", list.ToArray()));
            }

            return sb.ToString();
        }
    }
}
