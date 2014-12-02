using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public interface IFileMapper
    {
        Dictionary<DateTime, SeriesInfo> MapToSeries(string fileName);
    }
}
