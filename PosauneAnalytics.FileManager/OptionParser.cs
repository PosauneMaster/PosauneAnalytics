using PosauneAnalytics.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PosauneAnalytics.FileManager
{
    public class OptionParser
    {
        private ISettlementUtils _utils;
        private IComputationEngine _computationEngine;

        public OptionParser() { }

        public OptionParser(ISettlementUtils utils)
        {
            _utils = utils;
            _computationEngine = new ComputationEngine();
        }

        public List<OptionSettlement> GetOptions(string symbol, XmlNodeList nodeList)
        {
            var options = new List<OptionSettlement>();
            foreach (XmlNode node in nodeList)
            {
                SecurityType secType = _utils.GetSecurityType(node);

                if (secType == SecurityType.Call || secType == SecurityType.Put)
                {
                    options.Add(new OptionSettlement(_utils, node));
                }
            }

            return options.Where(o => o.Symbol == symbol).ToList();
        }
    }
}
