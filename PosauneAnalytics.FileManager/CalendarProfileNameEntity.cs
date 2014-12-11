using Microsoft.WindowsAzure.Storage.Table;

namespace PosauneAnalytics.FileManager
{
    public class CalendarProfileNameEntity : TableEntity
    {
        public CalendarProfileNameEntity() { }

        public CalendarProfileNameEntity(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }

        public string Name { get; set; }
    }
}
