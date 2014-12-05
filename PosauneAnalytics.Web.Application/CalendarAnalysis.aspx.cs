using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Web.Application
{
    public partial class CalendarAnalysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod()]
        public static void AjaxPost(CalendarEvent e)
        {
            Debug.WriteLine("AjaxPost");

        }

        public class CalendarEvent
        {
            public string EventDate { get; set; }
            public string Weight { get; set; }
        }



    }
}