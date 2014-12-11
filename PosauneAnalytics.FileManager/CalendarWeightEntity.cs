using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public class CalendarWeightEntity : TableEntity
    {
        public CalendarWeightEntity() { }

        public CalendarWeightEntity(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }

        public string CalendarProfile { get; set; }
        public DateTime Date { get; set; }
        public string Weight { get; set; }
    }
}
