using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Web.Application
{
    public partial class CalendarAnalytics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Page Load");
            txtAnalysisDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtExpirationDate1.Attributes.Add("onchange", "calcDateDiff('#txtExpirationDate1', '#txtDays1');");
            txtExpirationDate2.Attributes.Add("onchange", "calcDateDiff('#txtExpirationDate2', '#txtDays2');");
            txtExpirationDate3.Attributes.Add("onchange", "calcDateDiff('#txtExpirationDate3', '#txtDays3');");
            txtExpirationDate4.Attributes.Add("onchange", "calcDateDiff('#txtExpirationDate4', '#txtDays4');");
            txtExpirationDate5.Attributes.Add("onchange", "calcDateDiff('#txtExpirationDate5', '#txtDays5');");
            txtExpirationDate6.Attributes.Add("onchange", "calcDateDiff('#txtExpirationDate6', '#txtDays6');");
            txtExpirationDate7.Attributes.Add("onchange", "calcDateDiff('#txtExpirationDate7', '#txtDays7');");
            txtExpirationDate8.Attributes.Add("onchange", "calcDateDiff('#txtExpirationDate8', '#txtDays8');");
            txtExpirationDate9.Attributes.Add("onchange", "calcDateDiff('#txtExpirationDate9', '#txtDays9');");
            txtExpirationDate10.Attributes.Add("onchange", "calcDateDiff('#txtExpirationDate10', '#txtDays10');");

        }

        [System.Web.Services.WebMethod]
        public static void AjaxPost()
        {
            Debug.WriteLine("AjaxPost");
        }

        public class CalendarEvent
        {
            public DateTime Date { get; set; }
            public double Weight { get; set; }
        }



    }
}