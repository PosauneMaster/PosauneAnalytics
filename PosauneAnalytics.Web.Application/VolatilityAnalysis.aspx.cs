﻿using AjaxControlToolkit;
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
        }

        protected void btnRunAnalysis_Click(object sender, EventArgs e)
        {
            DateTime selectedDate;
            if (!DateTime.TryParse(txtAnalysisDate.Text, out selectedDate))
            {
                return;
            }

            var seriesDataList = _controller.Run(selectedDate);

            tcVolGrids.Visible = true;

            foreach(var data in seriesDataList)
            {
                TabPanel panel = new TabPanel();
                panel.HeaderText = data.SeriesName;

                var control = Page.LoadControl("~/ucVolatiltyTabContent.ascx");
                panel.Controls.Add(control);
                tcVolGrids.Tabs.Add(panel);

                ((TextBox)control.FindControl("txtSeries1")).Text = data.SeriesName;
                ((TextBox)control.FindControl("txtUnderlying1")).Text = data.Underlying;
                ((TextBox)control.FindControl("txtSymbol1")).Text = data.Symbol;
                ((TextBox)control.FindControl("txtUnderlyingPrice1")).Text = data.Price;

                var gv = ((GridView)control.FindControl("gvSeriesInfo1"));
                gv.DataSource = data.Model;
                gv.DataBind();

            }
        }

        protected void gvSeriesInfo1_RowCreated(object sender, GridViewRowEventArgs e)
        {

            GridView gv = sender as GridView;

            if (e.Row.RowType == DataControlRowType.Header)
            {

                var headerGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                headerGridRow.Cells.Add(new TableCell()
                {
                    Text = "Calls",
                    ColumnSpan = 2,
                    CssClass = "header_grid"
                });

                headerGridRow.Cells.Add(new TableCell()
                {
                    Text = "",
                    CssClass = "header_grid"

                });

                headerGridRow.Cells.Add(new TableCell()
                {
                    Text = "Puts",
                    ColumnSpan = 2,
                    CssClass = "header_grid"
                });

                gv.Controls[0].Controls.AddAt(0, headerGridRow);

            }
        }

    }
}