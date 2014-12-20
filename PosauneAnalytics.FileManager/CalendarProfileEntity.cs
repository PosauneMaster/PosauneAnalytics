using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class CalendarProfileEntity : TableEntity
    {
        public CalendarProfileEntity() { }

        public CalendarProfileEntity(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public string CalendarProfileJson { get; set; }
    }
}
