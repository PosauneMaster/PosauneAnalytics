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
            CloudTable table = CreateTableAsync(GetTableName(username)).Result;

            TableQuery<CalendarProfileEntity> partitionQuery = new TableQuery<CalendarProfileEntity>().Where(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, username));

            TableContinuationToken token = null;
            partitionQuery.TakeCount = 50;
            do
            {
                TableQuerySegment<CalendarProfileEntity> segment = await table.ExecuteQuerySegmentedAsync(partitionQuery, token).ConfigureAwait(false);
                token = segment.ContinuationToken;
                foreach (CalendarProfileEntity entity in segment)
                {
                    list.Add(entity.RowKey);
                }
            }
            while (token != null);

            return list;
        }

        public void StoreCalendarProfile(string username, string profileName, string calendarProfileJson)
        {
            string tablename = GetTableName(username);
            CloudTable table = CreateTableAsync(tablename).Result;
            CalendarProfileEntity entity = new CalendarProfileEntity(username, profileName)
            {
                CalendarProfileJson = calendarProfileJson
            };

            StoreEntityAsync(table, entity).Wait(10000);
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

        public string RetrieveProfile(string username, string profileName)
        {
            string tablename = GetTableName(username);
            CloudTable table = CreateTableAsync(tablename).Result;
            CalendarProfileEntity profile = RetrieveEntityUsingPointQueryAsync(table, username, profileName).Result;
            return profile.CalendarProfileJson;
        }

        /// <summary>
        /// Demonstrate the most efficient storage query - the point query - where both partition key and row key are specified. 
        /// </summary>
        /// <param name="table">Sample table name</param>
        /// <param name="partitionKey">Partition key - ie - last name</param>
        /// <param name="rowKey">Row key - ie - first name</param>
        private static async Task<CalendarProfileEntity> RetrieveEntityUsingPointQueryAsync(CloudTable table, string partitionKey, string rowKey)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<CalendarProfileEntity>(partitionKey, rowKey);
            TableResult result = await table.ExecuteAsync(retrieveOperation).ConfigureAwait(false);
            CalendarProfileEntity profile = result.Result as CalendarProfileEntity;
            //if (customer != null)
            //{
            //    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", customer.PartitionKey, customer.RowKey, customer.Email, customer.PhoneNumber);
            //}

            return profile;
        }


    }
}
