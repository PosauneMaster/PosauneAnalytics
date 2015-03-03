using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Volatility.Web.Application
{
    public partial class VolatilityAnalysis : System.Web.UI.Page
    {
        private IVolatilityAnalysisController _controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            _controller = new VolatilityAnalysisController()
            {
                Username = "Admin"
            };

            //calAnalysisDate.StartDate = _controller.MinDate;
            //calAnalysisDate.EndDate = _controller.MaxDate;

            if (!IsPostBack)
            {
                LoadCalendarProfiles();
            }
        }

        private void LoadCalendarProfiles()
        {
            var calendarController = new CalendarAnalysisController();

            ddlProfilenames.DataSource = calendarController.GetProfileNames("Admin");
            ddlProfilenames.DataBind();
        }

        protected void btnRunAnalysis_Click(object sender, EventArgs e)
        {
            DateTime selectedDate;
            if (!DateTime.TryParse(txtAnalysisDate.Text, out selectedDate))
            {
                return;
            }

            var seriesDataList = _controller.Run(selectedDate, ddlProfilenames.SelectedValue);

            tcVolGrids.Visible = true;

            foreach (var data in seriesDataList)
            {
                TabPanel panel = new TabPanel();
                panel.HeaderText = data.SeriesName;

                var control = Page.LoadControl("~/ucVolatiltyTabContent.ascx");
                panel.Controls.Add(control);
                tcVolGrids.Tabs.Add(panel);

                //((TextBox)control.FindControl("txtSeries1")).Text = data.SeriesName;
                //((TextBox)control.FindControl("txtUnderlying1")).Text = data.Underlying;
                //((TextBox)control.FindControl("txtSymbol1")).Text = data.Symbol;
                //((TextBox)control.FindControl("txtUnderlyingPrice1")).Text = data.Price;
                //((TextBox)control.FindControl("txtExpirationDate")).Text = data.ExpirationDate;
                //((TextBox)control.FindControl("txtDaysToExpiration")).Text = data.DaysToExpiration;
                //((TextBox)control.FindControl("txtWeightedDays")).Text = data.WeightedDaysToExpiration;
                //((TextBox)control.FindControl("txtRiskFreeRate")).Text = data.RiskFreeRate;

                var gv = ((GridView)control.FindControl("gvSeriesInfo1"));
                gv.DataSource = data.Model;
                gv.DataBind();

            }
        }
    }
}