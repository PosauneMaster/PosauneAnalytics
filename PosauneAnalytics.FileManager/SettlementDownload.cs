using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class SettlementDownload
    {
        public string Target { get; set; }
        public string FileName { get; set; }
        public MemoryStream FileStream { get; set; }
        public bool IsError { get; set; }
        public string ErrorMsg { get; set; }
    }
}
