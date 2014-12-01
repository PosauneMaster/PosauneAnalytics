using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PosauneAnalytics.FileManager
{
    public class FuturesParser
    {
        private ISettlementUtils _utils;

        public FuturesParser() { }

        public FuturesParser(ISettlementUtils utils)
        {
            _utils = utils;
        }

        public List<Settlement> GetFutures(string symbol, XmlNodeList nodeList)
        {
            var futures = new List<Settlement>();
            foreach (XmlNode node in nodeList)
            {
                SecurityType secType = _utils.GetSecurityType(node);

                if (secType == SecurityType.Future)
                {
                    futures.Add(new Settlement(_utils, node));
                }
            }

            return futures.Where(f => f.Symbol == symbol).ToList();
        }
    }
}
