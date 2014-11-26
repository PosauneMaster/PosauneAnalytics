using PosauneAnalytics.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Web.Application
{
    public partial class DownloadManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ICmeDownloader downloader = new CmeDownloader();

            var availableFiles = downloader.ListDirectoryDetails();

            gvAvailableFiles.DataSource = availableFiles;

            gvAvailableFiles.DataBind();

            List<string> myList = new List<string>();
            myList.Add("myString");
            GridView1.DataSource = myList;
            GridView1.DataBind();


        }
    }
}