using PosauneAnalytics.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.Web.Application
{
    public class CalendarAnalysisController
    {
        private CalendarProfile _calendarProfile;

        public CalendarAnalysisController()
        {
            _calendarProfile = new CalendarProfile();
        }

        public void AddCalenderEvent(IEnumerable<CalendarEvent> calendarEvents)
        {
            foreach (var ce in calendarEvents)
            {
                _calendarProfile.AddEvent(ce);
            }
        }

        public void SendProfileToStorage(string username, string profilename)
        {
            string json = _calendarProfile.ToJson(profilename);

            TableStorageManager tableStorage = new TableStorageManager();
            tableStorage.StoreCalendarProfile(username, profilename, json);
        }

        public List<string> GetProfileNames(string username)
        {
            TableStorageManager tableStorage = new TableStorageManager();
            var list = new List<string>();
            list.Add("None");
            list.AddRange(tableStorage.GetProfileNames(username));
            return list;
        }

        public List<CalendarEvent> GetCalendarEvents(string username, string profileName)
        {
            _calendarProfile.Clear();

            TableStorageManager tableStorage = new TableStorageManager();
            string profileJson = tableStorage.RetrieveProfile(username, profileName);
            CalendarProfile profile = CalendarProfile.ReHydrate(profileJson);

            return profile.EventList;
        }

        public void RemovEvents(IEnumerable<CalendarEvent> calendarEvents)
        {
            foreach (var ce in calendarEvents)
            {
                _calendarProfile.RemoveEvent(ce);
            }
        }

        public void ClearAllEvents()
        {
            _calendarProfile.Clear();
        }
    }
}
