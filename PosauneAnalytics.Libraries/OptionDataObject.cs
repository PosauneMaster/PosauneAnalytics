using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.Libraries
{
    public class OptionDataObject
    {
        public double AssetPrice { get; set; }
        public double Strike { get; set; }
        public double TimeToMaturity { get; set; }
        public double RiskFreeRate { get; set; }
        public double CostOfCarry { get; set; }
        public SecurityType PutCall { get; set; }
    }
}
