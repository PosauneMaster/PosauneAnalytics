using PosauneAnalytics.FileManager;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Web.Application
{
    public partial class VolatilityAnalysis : System.Web.UI.Page
    {
        private IVolatilityAnalysisController _controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            _controller = new VolatilityAnalysisController();

            calAnalysisDate.StartDate = _controller.MinDate;
            calAnalysisDate.EndDate = _controller.MaxDate;

            //tabPanel1.HeaderText = "tab panel 1";
        }

        protected void btnRunAnalysis_Click(object sender, EventArgs e)
        {
            DateTime selectedDate;
            if (!DateTime.TryParse(txtAnalysisDate.Text, out selectedDate))
            {
                return;
            }

            var seriesDataList = _controller.Run(selectedDate);

            SeriesData data = seriesDataList[0];

            tabPanel1.HeaderText = data.SeriesName;
            txtSeries1.Text = data.SeriesName;
            txtUnderlying1.Text = data.Underlying;
            txtSymbol1.Text = data.Symbol;
            txtUnderlyingPrice1.Text = data.Price;
            gvSeriesInfo1.DataSource = data.Model;

            gvSeriesInfo1.DataBind();

        }

    }
}