using System;
using System.Collections.Generic;

namespace PosauneAnalytics.Web.Application
{
    public interface ICalendarService
    {
        double ComputeWeightedTime(DateTime analysisDate, DateTime expiration);
        double ComputeWeightedDays(DateTime analysisDate, DateTime expiration);
        Dictionary<DateTime, double> ComputeAdjustments(DateTime analysisDate, IEnumerable<DateTime> expirations);
        string Profilename { get; set; }
        string Username { get; set; }
    }
}
