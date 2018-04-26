using System.Web;
using System.Web.Optimization;

namespace Jarcet.Qoute.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/content/js/adminlte.min.js",
                "~/content/js/init.js",
                "~/Content/js/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                   "~/Content/js/bootstrap.js",
                   "~/Content/js/respond.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/content/css/AdminLTE.css",
                      "~/content/css/skins/_all-skins.min.css",
                      "~/Content/font-awesome.css",
                      "~/content/fontello.css",
                      "~/Content/css/site.css"));
        }
    }
}
