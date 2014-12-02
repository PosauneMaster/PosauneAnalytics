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