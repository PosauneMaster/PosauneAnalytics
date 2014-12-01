using PosauneAnalytics.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Web.Application
{
    public partial class VolatilityAnalysis : System.Web.UI.Page
    {
        private IDownloadService _downloadService;

        protected void Page_Load(object sender, EventArgs e)
        {
            _downloadService = new DownloadService();

            var downloadedFiles = _downloadService.GetDownloadedFiles();

            cboAvailableFiles.DataSource = downloadedFiles;
            cboAvailableFiles.DataBind();
        }
    }
}