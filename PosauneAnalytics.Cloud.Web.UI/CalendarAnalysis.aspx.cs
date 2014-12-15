using PosauneAnalytics.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Cloud.Web.UI
{
    public partial class CalendarAnalysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCalendarProfiles();
        }

        private void LoadCalendarProfiles()
        {
            TableStorageManager tableManager = new TableStorageManager();
            var names = tableManager.GetProfileNames("Admin1");
            cboProfiles.DataSource = names;
            cboProfiles.DataBind();

        }


        [System.Web.Services.WebMethod()]
        public static void AjaxPost(List<CalendarEvent> calEvents)
        {
            Debug.WriteLine("AjaxPost");

        }

        public class CalendarEvent
        {
            public string EventDate { get; set; }
            public string Weight { get; set; }
        }

        protected void btnProfileName_Click(object sender, EventArgs e)
        {

        }
    }
}
