using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class CloudStorageAccountManager : ICloudStorageAccountManager
    {
        internal const string connectonString = "UseDevelopmentStorage=true;";

        public CloudStorageAccount CreateStorageAccount()
        {
            CloudStorageAccount storageAccount;
            try
            {
                string storageConnectionString = GetConnectionString();
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }

            return storageAccount;
        }

        private string GetConnectionString()
        {
            string connectionStr = CloudConfigurationManager.GetSetting("StorageConnectionString");

            if (String.IsNullOrEmpty(connectionStr))
            {
                return connectonString;
            }

            return connectionStr;
        }

    }
}
