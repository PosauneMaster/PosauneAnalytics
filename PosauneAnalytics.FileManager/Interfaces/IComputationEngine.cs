using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public interface IComputationEngine
    {
        double RiskFreeRate { get; set; }
        //double DaysToExpiration { get; set; }

        void ComputeImplied(OptionSettlement option);
        void ComputeSeriesAnalysis(IEnumerable<SeriesInfo> seriesInfo);
    }
}
