using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.Web.Application
{
    public class CalendarEvent
    {
        public string EventDate { get; set; }
        public string Weight { get; set; }

        public DateTime GetEventDate()
        {
            DateTime dt;
            if (DateTime.TryParse(EventDate, out dt))
            {
                return dt;
            }

            return DateTime.MaxValue;
        }

        public double GetEventWeight()
        {
            double weight;
            if (Double.TryParse(Weight, out weight))
            {
                return weight;
            }

            return 0.00d;
        }
    }
}
