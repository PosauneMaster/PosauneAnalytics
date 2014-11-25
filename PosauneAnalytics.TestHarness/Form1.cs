using PosauneAnalytics.FileManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosauneAnalytics.TestHarness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            CmeDownloader downloader = new CmeDownloader(date);
            var download = downloader.Download();

            IBlobManager blob = new BlobManager();
            blob.Upload(download.FileStream, download.FileName);
        }

        private void btnListBlob_Click(object sender, EventArgs e)
        {
            IBlobManager blob = new BlobManager();
            var blobList = blob.GetBlobs();
        }

        private void btnDownloadBlob_Click(object sender, EventArgs e)
        {
            string fileName = "cbt.settle.20141124.e.xml.zip";
            IBlobManager blob = new BlobManager();
            MemoryStream ms = blob.Download(fileName);

            ZipUtils zu = new ZipUtils();
            zu.UnZip(ms, fileName);
        }
    }
}
