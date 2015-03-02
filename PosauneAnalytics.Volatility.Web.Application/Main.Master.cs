using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PosauneAnalytics.Volatility.Web.Application
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Scripts.Render("~/bundles/jQuery");
            Scripts.Render("~/bundles/BootstrapJs");
            Styles.Render("~/bundles/BootstrapCss");

        }
    }
}