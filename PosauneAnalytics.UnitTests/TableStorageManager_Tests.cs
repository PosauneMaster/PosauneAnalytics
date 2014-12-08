using NUnit.Framework;
using PosauneAnalytics.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;


namespace PosauneAnalytics.UnitTests
{
    [TestFixture]
    public class TableStorageManager_Tests
    {
        [Test]
        public void AddCalenderWeight_Test()
        {
            var tableManager = new TableStorageManager();
            tableManager.StoreCalendar("Main", "admin", DateTime.Now.ToString("yyyyMMdd"), "1.23456");
                //tableManager.AddCalenderWeight("testTableName", "admin", DateTime.Now, 2.345d);

        }
    }
}
