using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class TableStorageManager
    {
        private ICloudStorageAccountManager _cloudStorageAccountManager;
        private CloudStorageAccount _cloudStorageAccount;

        internal const string connectonString = "UseDevelopmentStorage=true;";

        public TableStorageManager()
        {
            _cloudStorageAccountManager = new CloudStorageAccountManager();
            _cloudStorageAccount =  _cloudStorageAccountManager.CreateStorageAccount();

        }

        public async Task<List<string>> GetPartitionNames(string tableName, string partitionKey)
        {
            CloudTable table = CreateTableAsync(tableName).Result;

            TableQuery<CalendarWeightEntity> partitionQuery = new TableQuery<CalendarWeightEntity>().Where(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));

            TableContinuationToken token = null;
            partitionQuery.TakeCount = 50;
            do
            {
                TableQuerySegment<CalendarWeightEntity> segment = await table.ExecuteQuerySegmentedAsync(partitionQuery, token);
                token = segment.ContinuationToken;
                foreach (CalendarWeightEntity entity in segment)
                {
                    string wgt = entity.Weight;
                }
            }
            while (token != null);

            return null;

        }

        public void StoreCalendar(string tableName, string partitionKey, string rowKey, string weight)
        {
            CloudTable table = CreateTableAsync(tableName).Result;
            StoreEntityAsync(table, partitionKey, rowKey, weight).Wait();
        }

        private async Task<CloudTable> CreateTableAsync(string tableName)
        {
            CloudTableClient tableClient = _cloudStorageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference(tableName);
            await table.CreateIfNotExistsAsync();

            return table;
        }

        private static async Task StoreEntityAsync(CloudTable table, string partition, string rowKey, string weight)
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
