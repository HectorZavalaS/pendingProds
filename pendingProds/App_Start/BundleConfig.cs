using System.Web;
using System.Web.Optimization;

namespace pendingProds
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      //"~/Scripts/DataTables/dataTables.bootstrap.js",
                      "~/Scripts/DataTables/dataTables.fixedColumns.js",
                      //"~/Scripts/DataTables/dataTables.scroller.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap-dialog.js",
                      "~/Scripts/bootstrap-select.js",
                      "~/Scripts/jquery-check-all.js",
                      "~/Scripts/bootbox.min.js",
                      "~/Scripts/DataTables/dataTables.buttons.js",
                      "~/Scripts/DataTables/buttons.flash.js",
                      "~/Scripts/jszip.min.js",
                      "~/Scripts/pdfmake/pdfmake.min.js",
                      "~/Scripts/pdfmake/vfs_fonts.js",
                      "~/Scripts/DataTables/buttons.html5.js",
                      "~/Scripts/DataTables/buttons.print.js",
                      "~/Scripts/functions.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/style_light.css",
                      "~/Content/bootstrap-datepicker.css",
                      //"~/Content/DataTables/css/scroller.jqueryui.css",
                      "~/Content/bootstrap-dialog.css",
                      "~/Content/bootstrap-select.css",
                      "~/Content/DataTables/css/buttons.dataTables.css",
                      "~/Content/site.css"));
        }
    }
}
