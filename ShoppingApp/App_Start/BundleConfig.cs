using System.Web;
using System.Web.Optimization;

namespace ShoppingApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/dataTablesJs").Include(
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/dataTablesCss").Include(
                "~/Content/DataTables/css/dataTables.bootstrap.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                "~/Content/font-awesome.min.css"));
            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                "~/Content/bootstrap.css",
                "~/Content/sb-admin.css",
                "~/Content/font-awesome.min.css",
                "~/Content/genius-admin.css"));
            bundles.Add(new StyleBundle("~/Content/frontendcss").Include(
                "~/Content/Frontend/bootstrap.min.css",
                "~/Content/Frontend/default.css",
                "~/Content/Frontend/nivo-slider.css",
                "~/Content/Frontend/owl.carousel.css",
                "~/Content/Frontend/font-awesome.min.css",
                "~/Content/Frontend/animate.css",
                "~/Content/Frontend/jquery-ui.min.css",
                "~/Content/Frontend/meanmenu.css",
                "~/Content/Frontend/owl.carousel.css",
                "~/Content/Frontend/jquery.fancybox.css",
                "~/Content/Frontend/style.css",
                "~/Content/Frontend/responsive.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/frontendjs").Include(
                "~/Scripts/Frontend/vendor/jquery-1.12.0.min.js",
                "~/Scripts/Frontend/bootstrap.min.js",
                "~/Scripts/Frontend/jquery.nivo.slider.pack.js",
                "~/Scripts/Frontend/owl.carousel.min.js",
                "~/Scripts/Frontend/jquery.mixitup.js",
                "~/Scripts/Frontend/wow.min.js",
                "~/Scripts/Frontend/jquery.counterup.min.js",
                "~/Scripts/Frontend/waypoints-min.js",
                "~/Scripts/Frontend/jquery-ui.min.js",
                "~/Scripts/Frontend/jquery.countdown.min.js",
                "~/Scripts/Frontend/jquery.elevateZoom-3.0.8.min.js",
                "~/Scripts/Frontend/jquery.fancybox.pack.js",
                "~/Scripts/Frontend/jquery.meanmenu.js",
                "~/Scripts/Frontend/jquery.scrollUp.js",
                "~/Scripts/Frontend/plugins.js",
                "~/Scripts/Frontend/main.js"                
                
                ));
        }
    }
}
