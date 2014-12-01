using PosauneAnalytics.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace PosauneAnalytics.FileManager
{

    public class CmeDownloader : ICmeDownloader
    {
        private string _ftpTarget;
        private string _fileTemplate;

        public CmeDownloader()
        {
            ReadConfig();
        }

        public CmeDownloader(DateTime date)
        {
            ReadConfig();
        }

        private void ReadConfig()
        {
            _ftpTarget = ConfigurationManager.AppSettings["ftpTarget"];
            _fileTemplate = ConfigurationManager.AppSettings["fileTemplate"];

            if (String.IsNullOrEmpty(_ftpTarget))
            {
                Logger.LogError("ftpTarget is empty");
            }

            Logger.LogDebug(String.Format("Read ftpTarget={0} from configuration", _ftpTarget));
        }


        public SettlementDownload Download(string filename)
        {
            string ftpTarget = Path.Combine(_ftpTarget, filename);
            var downloadObj = new SettlementDownload()
            {
                Target = ftpTarget,
                FileName = filename,
                IsError = false
            };

            try
            {
                using (WebClient wc = new WebClient())
                {
                    byte[] bytes = wc.DownloadData(ftpTarget);
                    downloadObj.FileStream = new MemoryStream(bytes);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                downloadObj.IsError = true;
                downloadObj.ErrorMsg = ex.Message;
            }


            return downloadObj;
        }

        public SettlementDownload Download(DateTime date)
        {
            string filename = String.Format(_fileTemplate, date.ToString("yyyyMMdd"));

            return Download(filename);
        }

        public List<CmeFileDetails> ListDirectoryDetails()
        {
            const string fileNameMatch = "(c)(b)(t)(\\.)(s)(e)(t)(t)(l)(e)(\\.)(\\d+)(\\.)(e)(\\.)(x)(m)(l)(\\.)(z)(i)(p)";
            const string fileDetailsMatch = @"^([d-])([rwxt-]{3}){3}\s+\d{1,}\s+.*?(\d{1,})\s+(\w+\s+\d{1,2}\s+(?:\d{4})?)(\d{1,2}:\d{2})?\s+(.+?)\s?$";

            Regex regexFileName = new Regex(fileNameMatch, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Regex regexFileDetail = new Regex(fileDetailsMatch,
                RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);


            List<CmeFileDetails> list = new List<CmeFileDetails>();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_ftpTarget);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Match match = regexFileDetail.Match(line);
                if (match.Success)
                {

                    DateTime date;
                    DateTime.TryParse(match.Groups[4].ToString(), out date);

                    TimeSpan time;
                    TimeSpan.TryParse(match.Groups[5].ToString(), out time);

                    string fileName = match.Groups[6].ToString();

                    Match m = regexFileName.Match(fileName);
                    if (m.Success)
                    {
                        CmeFileDetails details = new CmeFileDetails();

                        details.TimeStamp = date.Add(time);
                        details.FileName = fileName;

                        list.Add(details);
                    }
                }
            }
            return list;
        }
    }
}
