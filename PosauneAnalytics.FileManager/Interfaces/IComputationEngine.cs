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

        void ComputeImplied(OptionSettlement option);
        Dictionary<Guid, SeriesInfo> ComputeSeriesAnalysis(IEnumerable<SeriesInfo> seriesInfo);
        Dictionary<Guid, SeriesInfo> ComputeSeriesAnalysisWeighted(IEnumerable<SeriesInfo> seriesInfo);
    }
}
