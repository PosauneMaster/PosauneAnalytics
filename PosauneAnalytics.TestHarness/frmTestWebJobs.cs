using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Configuration;
using Newtonsoft.Json;
using System.Diagnostics;

namespace PosauneAnalytics.TestHarness
{
    public partial class frmTestWebJobs : Form
    {
        private CloudQueue _posauseJobsQueue;

        public frmTestWebJobs()
        {
            InitializeComponent();
        }

        private void frmTestWebJobs_Load(object sender, EventArgs e)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ToString());
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            _posauseJobsQueue = queueClient.GetQueueReference("downloadrequest");
            _posauseJobsQueue.CreateIfNotExists();
        }

        private void btnCallJob_Click(object sender, EventArgs e)
        {
            CallDownloadWebJob();
        }

        public async void CallDownloadWebJob()
        {
            try
            {
                var downloadInfo = new DownloadInfo() { Source = "CME Option Settlements" };
                var queueMessage = new CloudQueueMessage(JsonConvert.SerializeObject(downloadInfo));
                await _posauseJobsQueue.AddMessageAsync(queueMessage);

                Trace.TraceInformation("Created queue message for download job {0}", downloadInfo.Id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    public class DownloadInfo
    {
        public string Id { get; private set; }
        public string Source { get; set; }

        public DownloadInfo()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
