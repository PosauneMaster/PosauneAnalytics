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

        //internal const string connectonString = "UseDevelopmentStorage=true;";
        internal const string calendarProfileNamesTable = "CalendarProfileNames";
 
        public TableStorageManager()
        {
            _cloudStorageAccountManager = new CloudStorageAccountManager();
            _cloudStorageAccount =  _cloudStorageAccountManager.CreateStorageAccount();

        }

        public List<string> GetProfileNames(string username)
        {
            var list = new List<string>();
            list = GetProfileNamesAsync(username).Result;
            return list;
        }

        public async Task<List<string>> GetProfileNamesAsync(string username)
        {
            List<string> list = new List<string>();
            CloudTable table = CreateTableAsync(calendarProfileNamesTable).Result;

            TableQuery<CalendarProfileNameEntity> partitionQuery = new TableQuery<CalendarProfileNameEntity>().Where(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, username));

            TableContinuationToken token = null;
            partitionQuery.TakeCount = 50;
            do
            {
                TableQuerySegment<CalendarProfileNameEntity> segment = await table.ExecuteQuerySegmentedAsync(partitionQuery, token).ConfigureAwait(false);
                token = segment.ContinuationToken;
                foreach (CalendarProfileNameEntity entity in segment)
                {
                    list.Add(entity.Name);
                }
            }
            while (token != null);

            return list;
        }

        public List<CalendarWeightEntity> GetWeights(string username, string profilename)
        {
            var list = new List<CalendarWeightEntity>();
            list = GetWeightsAsync(username, profilename).Result;

            return list;
        }

        public async Task<List<CalendarWeightEntity>> GetWeightsAsync(string username, string profilename)
        {
            string tableName = GetTableName(username);
            CloudTable table = CreateTableAsync(tableName).Result;

            List<CalendarWeightEntity> list = new List<CalendarWeightEntity>();

            TableQuery<CalendarWeightEntity> partitionQuery = new TableQuery<CalendarWeightEntity>().Where(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, profilename));

            TableContinuationToken token = null;
            partitionQuery.TakeCount = 50;
            do
            {
                TableQuerySegment<CalendarWeightEntity> segment = await table.ExecuteQuerySegmentedAsync(partitionQuery, token).ConfigureAwait(false);
                token = segment.ContinuationToken;
                foreach (CalendarWeightEntity entity in segment)
                {
                    list.Add(new CalendarWeightEntity(entity.PartitionKey, entity.RowKey)
                    {
                        Weight=entity.Weight,
                        Date = entity.Date,
                        CalendarProfile = entity.CalendarProfile
                    });
                }
            }
            while (token != null);

            return list;
        }

        public void SaveCalendarProfileName(string partitionKey, string rowKey, string profileName)
        {
            CloudTable table = CreateTableAsync(calendarProfileNamesTable).Result;

            CalendarProfileNameEntity entity = new CalendarProfileNameEntity(partitionKey, rowKey);
            entity.Name = profileName;

            StoreEntityAsync(table, entity).Wait();

        }

        public void StoreCalendarWeight(string username, string partitionKey, DateTime date, string weight)
        {
            string tableName = GetTableName(username);
            CloudTable table = CreateTableAsync(tableName).Result;
            CalendarWeightEntity entity = new CalendarWeightEntity(partitionKey, date.ToString("yyyyMMdd"))
            {
                CalendarProfile = partitionKey,
                Weight = weight,
                Date = date
            };


            StoreEntityAsync(table, entity).Wait();

            SaveCalendarProfileName(username, partitionKey, partitionKey);

        }

        private async Task<CloudTable> CreateTableAsync(string tableName)
        {
            CloudTableClient tableClient = _cloudStorageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference(tableName);

            await table.CreateIfNotExistsAsync().ConfigureAwait(false);

            return table;
        }

        private static async Task StoreEntityAsync(CloudTable table, TableEntity entity)
        {
            entity = await InsertOrMergeEntityAsync(table, entity);
        }

        private static async Task<T> InsertOrMergeEntityAsync<T>(CloudTable table, T entity) where T: TableEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);
            TableResult result = await table.ExecuteAsync(insertOrMergeOperation).ConfigureAwait(false);
            T insertedEntity = result.Result as T;
            return insertedEntity;
        }

        private string GetTableName(string username)
        {
            return String.Format("calendarweights{0}", username);
        }
    }
}
