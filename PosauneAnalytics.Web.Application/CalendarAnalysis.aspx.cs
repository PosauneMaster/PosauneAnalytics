using PosauneAnalytics.FileManager;
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
        private static CalendarAnalysisController _controller = new CalendarAnalysisController();

        protected void Page_Load(object sender, EventArgs e)
        {

            LoadCalendarProfiles();
        }

        private void LoadCalendarProfiles()
        {
            var _controller = new CalendarAnalysisController();

            ddlProfilenames.DataSource = _controller.GetProfileNames("Admin");
            ddlProfilenames.DataBind();
        }


        [System.Web.Services.WebMethod()]
        public static void AjaxPost(List<CalendarEvent> calEvents)
        {
            Debug.WriteLine("AjaxPost");
            _controller.AddCalenderEvent(calEvents);

        }

        protected void btnProfileName_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProfilename.Text))
            {
                _controller.SendProfileToStorage("Admin", txtProfilename.Text);
            }
        }

        protected void btnProfilenameLoad_Click(object sender, EventArgs e)
        {

        }
    }
}