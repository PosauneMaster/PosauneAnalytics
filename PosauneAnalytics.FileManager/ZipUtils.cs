using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class ZipUtils :IZipUtils
    {
        public string UnZip(string file)
        {
            var ms =  new MemoryStream(System.Text.Encoding.UTF8.GetBytes(file));
            ZipFile zip = ZipFile.Read(ms);

            return String.Empty;
        }

        public string UnZip(MemoryStream stream, string fileName)
        {
            ZipFile zip = ZipFile.Read(stream);
            var entry = zip.First();
            MemoryStream ms = new MemoryStream();
            string xmlFile = String.Empty;

            entry.Extract(ms);
            ms.Position = 0;
            using (var sr = new StreamReader(ms))
            {
                xmlFile = sr.ReadToEnd();
            }

            return xmlFile;
        }

    }
}
