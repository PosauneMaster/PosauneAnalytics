using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.Web.Application
{
    public class CalendarService : ICalendarService
    {
        public string Username { get; set; }
        public string Profilename { get; set; }

        public CalendarService() { }

        public double ComputeWeightedDays(DateTime analysisDate, DateTime expiration)
        {
            double weight = 0.00d;
            CalendarAnalysisController controller = new CalendarAnalysisController();
            var events = controller.GetCalendarEvents(Username, Profilename);

            foreach (var day in events)
            {
                if (day.GetEventDate() <= expiration)
                {
                    weight += day.GetEventWeight();
                }
            }

            double weightedDays = (expiration - analysisDate).TotalDays + weight;
            return weightedDays;
        }

        public Dictionary<DateTime, double> ComputeAdjustments(DateTime analysisDate, IEnumerable<DateTime> expirations)
        {
            var adjustments = new Dictionary<DateTime, double>();

            foreach (var dt in expirations)
            {
                adjustments.Add(dt, ComputeWeightedDays(analysisDate, dt));
            }

            return adjustments;
        }
    }
}
