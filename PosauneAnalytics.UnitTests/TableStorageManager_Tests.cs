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
        //[Test]
        //public void AddCalenderWeight_Test()
        //{
        //    var tableManager = new TableStorageManager();
        //    //tableManager.StoreCalendar("Main", "admin", DateTime.Now.ToString("yyyyMMdd"), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin", "myCalendar1", DateTime.Now, "1.23456");
        //    tableManager.StoreCalendarWeight("Admin", "myCalendar1", DateTime.Now.AddDays(1), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin", "myCalendar1", DateTime.Now.AddDays(2), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin", "myCalendar1", DateTime.Now.AddDays(3), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin", "myCalendar1", DateTime.Now.AddDays(4), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin", "myCalendar3", DateTime.Now, "1.23456");
        //    tableManager.StoreCalendarWeight("Admin", "myCalendar2", DateTime.Now.AddDays(5), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin", "myCalendar3", DateTime.Now.AddDays(6), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin", "myCalendar4", DateTime.Now.AddDays(7), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin", "myCalendar5", DateTime.Now.AddDays(8), "1.23456");

        //    tableManager.StoreCalendarWeight("Admin1", "anotherCalendar6", DateTime.Now, "1.23456");
        //    tableManager.StoreCalendarWeight("Admin1", "anotherCalendar7", DateTime.Now.AddDays(1), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin1", "anotherCalendar8", DateTime.Now.AddDays(2), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin1", "anotherCalendar9", DateTime.Now.AddDays(3), "1.23456");
        //    tableManager.StoreCalendarWeight("Admin1", "anotherCalendar10", DateTime.Now.AddDays(4), "1.23456");



        //        //tableManager.AddCalenderWeight("testTableName", "admin", DateTime.Now, 2.345d);

        //}

        [Test]
        public void GetProfileNames_Test()
        {
            var tableManager = new TableStorageManager();
            List<string> names = tableManager.GetProfileNames("Admin1");
        }

        //[Test]
        //public void GetWeights_Test()
        //{
        //    var TableManager = new TableStorageManager();
        //    List<CalendarWeightEntity> list = TableManager.GetWeights("Admin", "myCalendar1");
        //}
    }
}
