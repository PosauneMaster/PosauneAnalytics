using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.Web.Application
{
    public interface IVolatilityAnalysisController
    {
        DateTime MinDate { get; }
        DateTime MaxDate { get; }

        List<SeriesData> Run(DateTime date, string profilename);
        string Username { get; set; }
    }
}
