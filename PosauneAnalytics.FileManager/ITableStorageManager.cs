using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.FileManager
{
    public interface ITableStorageManager
    {
        void AddCalenderWeight(string tableName, string partitionKey, DateTime date, double weight);
    }
}
