using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Web.Application
{
    public partial class ucVolatiltyTabContent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    ColumnSpan = 5,
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
                    ColumnSpan = 5,
                    CssClass = "header_grid"
                });

                gv.Controls[0].Controls.AddAt(0, headerGridRow);

                var subHeaderGridRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                subHeaderGridRow.Cells.Add(new TableCell()
                {
                    Text = "Theo Call",
                    ColumnSpan = 2,
                    CssClass = "header_grid"
                });

                subHeaderGridRow.Cells.Add(new TableCell()
                {
                    Text = "Implied Vol",
                    ColumnSpan = 2,
                    CssClass = "header_grid"
                });

                subHeaderGridRow.Cells.Add(new TableCell()
                {
                    Text = "",
                    CssClass = "header_grid"

                });

                subHeaderGridRow.Cells.Add(new TableCell()
                {
                    Text = "",
                    CssClass = "header_grid"

                });

                subHeaderGridRow.Cells.Add(new TableCell()
                {
                    Text = "",
                    CssClass = "header_grid"

                });

                subHeaderGridRow.Cells.Add(new TableCell()
                {
                    Text = "Implied Vol",
                    ColumnSpan = 2,
                    CssClass = "header_grid"
                });

                subHeaderGridRow.Cells.Add(new TableCell()
                {
                    Text = "Theo Put",
                    ColumnSpan = 2,
                    CssClass = "header_grid"
                });

                gv.Controls[0].Controls.AddAt(1, subHeaderGridRow);


            }
        }

    }
}