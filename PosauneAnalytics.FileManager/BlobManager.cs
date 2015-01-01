using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure;
using System.Diagnostics;
using System.IO;
using PosauneAnalytics.Logging;

namespace PosauneAnalytics.FileManager 
{
    public class BlobManager : IBlobManager
    {
        //private CloudStorageAccount _storageAccount;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _container;

        private ICloudStorageAccountManager _cloudStorageAccountManager;
        private CloudStorageAccount _cloudStorageAccount;


        public BlobManager()
        {
            _cloudStorageAccountManager = new CloudStorageAccountManager();
            _cloudStorageAccount = _cloudStorageAccountManager.CreateStorageAccount();

            _blobClient = _cloudStorageAccount.CreateCloudBlobClient();
            _container = _blobClient.GetContainerReference("cme-dailysettlements");


        }

        public bool Upload(MemoryStream stream, string fileName)
        {
            bool success = true;

            try
            {
                CloudBlockBlob blockBlob = _container.GetBlockBlobReference(fileName);
                blockBlob.UploadFromStream(stream);
            }
            catch (Exception ex)
            {
                Logger.LogError(String.Format("BlobManager.Upload, fileName={0}", fileName), ex);
                success =  false;
            }

            return success;
        }

        public MemoryStream Download(string blobName)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                var blockBlob = _container.GetBlockBlobReference(blobName);
                blockBlob.DownloadToStream(ms);
                ms.Position = 0;
            }
            catch(Exception ex)
            {
                Logger.LogError(String.Format("BlobManager.Download, blobName={0}", blobName), ex);
            }

            return ms;
        }

        public List<string> GetBlobs()
        {
            var blobList = new List<string>();

            foreach (IListBlobItem item in _container.ListBlobs())
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    blobList.Add(blob.Name);
                }
            }

            return blobList;
        }

    }
}
