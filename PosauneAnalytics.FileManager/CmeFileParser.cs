using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PosauneAnalytics.FileManager
{
    public class CmeFileParser : ICmeFileParser
    {
        private IZipUtils _zipUtils;
        private Dictionary<DateTime, SeriesInfo> _map = new Dictionary<DateTime, SeriesInfo>();

        public CmeFileParser()
        {
            _zipUtils = new ZipUtils();
        }

        public string Unpack(MemoryStream stream, string filename)
        {
            return _zipUtils.UnZip(stream, filename);
        }

        public Dictionary<DateTime, SeriesInfo> Parse(MemoryStream stream, string filename)
        {
            string xml = Unpack(stream, filename);
            return Parse(xml);
        }

        public Dictionary<DateTime, SeriesInfo> Parse(string xml)
        {
            ISettlementUtils utils = new SettlementUtils();

            StringReader sr = new StringReader(xml);


            XmlDocument doc = new XmlDocument();
            doc.Load(sr);
            XmlNodeList nodeList = doc.SelectNodes("FIXML/Batch/MktDataFull");

            var futuresParser = new FuturesParser(utils);
            var futures10yr = futuresParser.GetFutures("ZN", nodeList);

            var optionsParser = new OptionParser(utils);
            var options10yr = optionsParser.GetOptions("OZN", nodeList);

            foreach (var ty in futures10yr)
            {
                var myOptions = options10yr.Where(o => o.UnderlyingKey == ty.MonthYear);

                CreateSettlementMap(myOptions, ty);

            }

            return _map;

        }

        private void CreateSettlementMap(IEnumerable<OptionSettlement> optionSettlementList, Settlement ty)
        {
            foreach (var o in optionSettlementList)
            {

                if (!_map.ContainsKey(o.MaturityDate))
                {
                    _map.Add(o.MaturityDate, new SeriesInfo() { Underlying = ty, ExpirationDate = o.MaturityDate });
                }
                _map[o.MaturityDate].AddOption(o);
            }
        }


    }
}
