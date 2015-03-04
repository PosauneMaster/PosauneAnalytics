using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BootstrapDemo.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.IgnoreList.Ignore("*.intellisense.js");
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);

            bundles.Add(new ScriptBundle("~/bundles/jQuery").Include(
                  "~/Scripts/jquery-2.1.3.js"
                , "~/Scripts/jquery-2.1.3.intellisense.js"
                , "~/Scripts/jquery-ui-1.11.3.js"
                 ));

            bundles.Add(new ScriptBundle("~/bundles/BootstrapJs").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/FullCalendarJs").Include(
                "~/Scripts/fullcalendar.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/CalendarPageJs").Include(
                "~/Scripts/calendar-page-custom.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/BootstrapDatePickerJs").Include(
                "~/Scripts/bootstrap-datepicker.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/BootstrapCss").Include(
                  "~/Content/bootstrap.css"
                , "~/Content/bootstrap-theme-spacelab.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/FullCalendarCss").Include(
                "~/Content/fullcalendar.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/CalendarPageCss").Include(
                "~/Content/calendar-page-custom.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/BootstrapDatePickerCss").Include(
                "~/Content/datepicker3.css"));

            bundles.Add(new StyleBundle("~/bundles/VolatilityPageCss").Include(
                "~/Content/volitility-page-custom.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}

