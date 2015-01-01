using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PosauneAnalytics.FileManager
{
    public class OptionSettlement : Settlement
    {
        public double StrikePrice { get; set; }
        public double ImpliedVolatility { get; set; }
        public double Delta { get; set; }
        public double DaysToExpiration { get; set; }

        public string ImpliedVolatilityDisplay 
        {
            get { return ImpliedVolatility.ToString("P2"); }
        }
        public string UnderlyingKey { get; set; }
        public Settlement Underlying { get; set; }

        public OptionSettlement(ISettlementUtils utils, XmlNode node)
        {
            SettlementUtils = utils;
            Initialize(node);
        }

        protected override void Initialize(XmlNode node)
        {
            base.Initialize(node);

            XmlNode instrNode = SettlementUtils.GetInstrumentNode(node);
            StrikePrice = Double.Parse(SettlementUtils.GetStringFromNode(instrNode, "StrkPx"));

            XmlNode undlyNode = SettlementUtils.GetUnderlyingNode(node);
            UnderlyingKey = SettlementUtils.GetStringFromNode(undlyNode, "MMY");
        }
    }
}
