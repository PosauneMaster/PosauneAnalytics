using PosauneAnalytics.FileManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Web.Application
{
    public partial class CalendarAnalysis : System.Web.UI.Page
    {
        private static CalendarAnalysisController _controller = new CalendarAnalysisController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCalendarProfiles();
            }
        }

        private void LoadCalendarProfiles()
        {
            var _controller = new CalendarAnalysisController();

            ddlProfilenames.DataSource = _controller.GetProfileNames("Admin");
            ddlProfilenames.DataBind();
        }

        [System.Web.Services.WebMethod()]
        public static void AddEvent(List<CalendarEvent> calEvents)
        {
            try
            {
                _controller.AddCalenderEvent(calEvents);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }

        [System.Web.Services.WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<CalendarEvent> LoadProfile(string profilename)
        {
            var events = _controller.GetCalendarEvents("Admin", profilename);
            return events;
        }

        [System.Web.Services.WebMethod()]
        public static void RemoveEvents(List<CalendarEvent> calEvents)
        {
            _controller.RemovEvents(calEvents);
        }


        [System.Web.Services.WebMethod()]
        public static void ClearAllEvents()
        {
            _controller.ClearAllEvents();
        }

        protected void btnProfileNameSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProfilename.Text))
            {
                _controller.SendProfileToStorage("Admin", txtProfilename.Text);
                txtProfilename.Text = String.Empty;
                LoadCalendarProfiles();
            }
        }
    }
}