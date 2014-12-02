using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public interface ICmeFileParser
    {
        string Unpack(MemoryStream stream, string filename);
        Dictionary<DateTime, SeriesInfo> Parse(MemoryStream stream, string filename);
        Dictionary<DateTime, SeriesInfo> Parse(string xml);

    }
}
