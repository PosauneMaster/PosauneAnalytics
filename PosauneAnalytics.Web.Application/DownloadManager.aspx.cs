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
        private IDownloadService _downloadService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _downloadService = new DownloadService();

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {

            var availableFiles = _downloadService.ListFtpDirectoryDetails();

            gvAvailableFiles.DataSource = availableFiles;
            gvAvailableFiles.DataBind();

            var downloadedFiles = _downloadService.GetDownloadedFiles();

            gvDownloadedFiles.DataSource = downloadedFiles.Select(f => new { filename = f });
            gvDownloadedFiles.DataBind();
        }

        private bool HasRowsChecked()
        {
            foreach (GridViewRow row in gvAvailableFiles.Rows)
            {
                var cb = row.FindControl("chkSelected") as CheckBox;

                if (cb != null && cb.Checked)
                {
                    return true;
                }
            }

            return false;
        }

        private List<GridViewRow> GetCheckedRows()
        {
            var rowList = new List<GridViewRow>();

            foreach (GridViewRow row in gvAvailableFiles.Rows)
            {
                var cb = row.FindControl("chkSelected") as CheckBox;

                if (cb != null && cb.Checked)
                {
                    rowList.Add(row);
                }
            }

            return rowList;
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            var filenames = new List<string>();
            foreach (GridViewRow row in gvAvailableFiles.Rows)
            {
                var lbl = row.FindControl("lblFilename") as Label;
                if (lbl != null)
                {
                    filenames.Add(lbl.Text);
                }
            }
            _downloadService.DownloadSelected(filenames);

            LoadData();


        }
    }
}