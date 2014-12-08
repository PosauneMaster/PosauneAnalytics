using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace PosauneAnalytics.FileManager
{
    public class TableStorageManager
    {
        internal const string connectonString = "UseDevelopmentStorage=true;";

        public void StoreCalendar(string tableName, string partitionKey, string rowKey, string weight)
        {
            CloudTable table = CreateTableAsync(tableName).Result;
            BasicTableOperationsAsync(table, partitionKey, rowKey, weight).Wait();
        }

        private static async Task<CloudTable> CreateTableAsync(string tableName)
        {
            CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(connectonString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference(tableName);
            await table.CreateIfNotExistsAsync();

            return table;
        }

        private static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
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

        private static async Task BasicTableOperationsAsync(CloudTable table, string partition, string rowKey, string weight)
        {
            CalendarWeightEntity entity = new CalendarWeightEntity(partition, rowKey)
            {
                Weight = weight
            };

            entity = await InsertOrMergeEntityAsync(table, entity);
        }

        private static async Task<CalendarWeightEntity> InsertOrMergeEntityAsync(CloudTable table, CalendarWeightEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

            TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
            CalendarWeightEntity insertedCustomer = result.Result as CalendarWeightEntity;
            return insertedCustomer;
        }
    }
}
