using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Web.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static void TestAjax()
        {

        }
    }

    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public double Weight { get; set; }
    }
}