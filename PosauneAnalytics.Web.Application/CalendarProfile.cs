using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.Web.Application
{
    public class CalendarProfile
    {
        public string Name { get; set; }
        public List<CalendarEvent> EventList { get; set; }


        public CalendarProfile() : this("tempName") { }

        public CalendarProfile(string name)
        {
            Name = name;
            EventList = new List<CalendarEvent>();
        }

        public void AddEvent(CalendarEvent calendarEvent)
        {
            EventList.Add(calendarEvent);
        }

        public string ToJson(string name)
        {
            Name = name;
            return JsonConvert.SerializeObject(this);
        }

        public static CalendarProfile ReHydrate(string json)
        {
            return JsonConvert.DeserializeObject<CalendarProfile>(json);
        }
    }
}
