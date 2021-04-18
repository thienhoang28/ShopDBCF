using System.Web;
using System.Web.Optimization;

namespace WebApp1
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

            //Script bundle for AdminLTE
            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                        "~/Scripts/adminlte.min.js"));
            //Script bundle for UserPage
            bundles.Add(new ScriptBundle("~/bundles/userpage").Include(
                        "~/Content/UserContent/libs/font-awesome/js/all.js",
                        "~/Content/UserContent/libs/jquery/jquery-3.5.1.slim.js",
                        "~/Content/UserContent/libs/jquery/popper_1.12.9.min.js",
                        "~/Content/UserContent/libs/bootstrap/js/bootstrap.min.js"));
            //bundle ckeditor
            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                        "~/Scripts/ckeditor/ckeditor.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Style bundle for AdminLTE
            bundles.Add(new StyleBundle("~/Content/adminlte/css").Include(
                      "~/Content/fontawesome/all.min.css",
                      "~/Content/adminlte.min.css"));
            //Style bundle for UserPage
            bundles.Add(new StyleBundle("~/Content/userpage/css").Include(
                      "~/Content/UserContent/libs/bootstrap/css/bootstrap.min.css"));
        }
    }
}
