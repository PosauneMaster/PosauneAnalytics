using PosauneAnalytics.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PosauneAnalytics.FileManager
{
    public class Settlement
    {
        public DateTime BusinessDate { get; set; }
        public string Symbol { get; set; }
        public string MonthYear { get; set; }
        public DateTime MaturityDate { get; set; }
        public SecurityType SecurityType { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string TickPrice { get; set; }

        public double DollarPrice
        {
            get
            {
                double p;
                if (!Double.TryParse(Price, out p))
                {
                    return 0.00d;
                }
                return p;
            }
        }

        protected ISettlementUtils SettlementUtils { get; set; }

        public Settlement()
        {
        }


        public Settlement(ISettlementUtils utils, XmlNode node)
        {
            SettlementUtils = utils;
            Initialize(node);
        }

        protected virtual void Initialize(XmlNode node)
        {
            XmlNode instrNode = SettlementUtils.GetInstrumentNode(node);

            SecurityType = SettlementUtils.GetSecurityType(node);
            BusinessDate = SettlementUtils.GetDateTimeFromNode(node, "BizDt");
            Symbol = SettlementUtils.GetStringFromNode(instrNode, "Sym");
            MonthYear = SettlementUtils.GetStringFromNode(instrNode, "MMY");
            MaturityDate = SettlementUtils.GetDateTimeFromNode(instrNode, "MatDt");
            Price = SettlementUtils.GetPrice(node);
            SetDescription(MaturityDate);
            SetTickPrice(Price);
        }

        private void SetDescription(DateTime dt)
        {
            Description = String.Format("{0} {1}", dt.ToShortMonthName(), dt.Year);
        }

        private void SetTickPrice(string price)
        {
            if (Symbol == "ZN" || Symbol == "OZN")
            {
                decimal d = Decimal.Parse(price);
                int wholePart = (Int32)Math.Truncate(d);

                if (Symbol == "OZN")
                {
                    int fraction = (Int32)((d - Math.Truncate(d)) * 64);
                    TickPrice = String.Format("{0} {1}", wholePart, fraction.ToString("D2"));
                }
                else
                {
                    //decimal fraction = (d - Math.Truncate(d)) * 32 * 10;

                    //TickPrice = String.Format("{0} {1}", wholePart, Math.Truncate(fraction));

                    int fraction = (int)((d - Math.Truncate(d)) * 32 * 10);

                    TickPrice = String.Format("{0} {1}", wholePart, fraction.ToString("D3"));

                }


            }
            else
            {
                TickPrice = price;
            }
        }
    }
}
