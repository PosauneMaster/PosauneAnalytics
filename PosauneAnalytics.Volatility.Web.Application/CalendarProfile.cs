using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PosauneAnalytics.Volatility.Web.Application
{
    public class CalendarProfile
    {
        private Dictionary<string, CalendarEvent> calEventsIndex = new Dictionary<string, CalendarEvent>();

        public string Name { get; set; }
        public List<CalendarEvent> EventList { get; set; }


        public CalendarProfile() : this("tempName") { }

        public CalendarProfile(string name)
        {
            Name = name;
        }

        public void AddEvent(CalendarEvent calendarEvent)
        {
            if (calEventsIndex.ContainsKey(calendarEvent.EventDate))
            {
                calEventsIndex[calendarEvent.EventDate] = calendarEvent;
            }
            else
            {
                calEventsIndex.Add(calendarEvent.EventDate, calendarEvent);
            }
        }

        public string ToJson(string name)
        {
            EventList = new List<CalendarEvent>(calEventsIndex.Values);
            Name = name;
            return JsonConvert.SerializeObject(this);
        }

        public void RemoveEvent(CalendarEvent calendarEvent)
        {
            if (calEventsIndex.ContainsKey(calendarEvent.EventDate))
            {
                calEventsIndex.Remove(calendarEvent.EventDate);
            }
        }

        public void Clear()
        {
            calEventsIndex.Clear();
        }

        public static CalendarProfile ReHydrate(string json)
        {
            return JsonConvert.DeserializeObject<CalendarProfile>(json);
        }
    }
}