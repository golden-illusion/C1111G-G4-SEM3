using System.Web;
using System.Web.Optimization;

namespace Insurance
{
    public class BundleConfig
    {

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));


            /**
             * ***************************
             * Bundles for Admin Site ****
             * ***************************
             **/
            bundles.Add(new ScriptBundle("~/admin/bundles/jquery").Include(
                        "~/Areas/Admin/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/nicescroll").Include(
                        "~/Areas/Admin/Scripts/plugins/nicescroll/jquery.nicescroll.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/jquery-ui").Include(
                        "~/Areas/Admin/Scripts/plugins/jquery-ui/jquery.ui.widget.min.js",
                        "~/Areas/Admin/Scripts/plugins/jquery-ui/jquery.ui.mouse.min.js",
                        "~/Areas/Admin/Scripts/plugins/jquery-ui/jquery.ui.draggable.min.js",
                        "~/Areas/Admin/Scripts/plugins/jquery-ui/jquery.ui.resizable.min.js",
                        "~/Areas/Admin/Scripts/plugins/jquery-ui/jquery.ui.sortable.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/touch-punch").Include(
                        "~/Areas/Admin/Scripts/plugins/touch-punch/jquery.touch-punch.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/slimscroll").Include(
                        "~/Areas/Admin/Scripts/plugins/slimscroll/jquery.slimscroll.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/bootstrap").Include(
                        "~/Areas/Admin/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/bootbox").Include(
                        "~/Areas/Admin/Scripts/plugins/bootbox/jquery.bootbox.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/imagesLoaded").Include(
                        "~/Areas/Admin/Scripts/plugins/imagesLoaded/jquery.imagesloaded.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/chosen").Include(
                        "~/Areas/Admin/Scripts/plugins/chosen/chosen.jquery.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/select2").Include(
                        "~/Areas/Admin/Scripts/plugins/select2/select2.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/icheck").Include(
                        "~/Areas/Admin/Scripts/plugins/icheck/jquery.icheck.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/themes").Include(
                        "~/Areas/Admin/Scripts/eakroko.min.js",
                        "~/Areas/Admin/Scripts/application.min.js",
                        "~/Areas/Admin/Scripts/demonstration.min.js"));

            bundles.Add(new StyleBundle("~/admin/Content/bootstrap").Include(
                        "~/Areas/Admin/Content/css/bootstrap.css",
                        "~/Areas/Admin/Content/css/bootstrap-responsive.css"));

            bundles.Add(new StyleBundle("~/admin/Content/plugins/jquery-ui").Include(
                        "~/Areas/Admin/Content/css/plugins/jquery-ui/smoothness/jquery-ui.css",
                        "~/Areas/Admin/Content/css/plugins/jquery-ui/smoothness/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/admin/Content/plugins/chosen").Include(
                        "~/Areas/Admin/Content/css/plugins/chosen/chosen.css"));

            bundles.Add(new StyleBundle("~/admin/Content/plugins/select2").Include(
                        "~/Areas/Admin/Content/css/plugins/select2/select2.css"));

            bundles.Add(new StyleBundle("~/admin/Content/plugins/icheck").Include(
                        "~/Areas/Admin/Content/css/plugins/icheck/all.css"));

            bundles.Add(new StyleBundle("~/admin/Content/style").Include(
                        "~/Areas/Admin/Content/css/style.css"));

            bundles.Add(new StyleBundle("~/admin/Content/themes").Include(
                        "~/Areas/Admin/Content/css/themes.css"));

            /**
             * ***************************
             * End ***********************
             * ***************************
             **/

            /**
             * ***************************
             * Client ********************
             * ***************************
             **/


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/main").Include("~/Scripts/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/slider").Include(
                        "~/Scripts/jquery.themepunch.plugins.min.js",
                        "~/Scripts/jquery.themepunch.revolution.min.js",
                        "~/Scripts/revolution-slider-options.js"));
            bundles.Add(new ScriptBundle("~/bundles/prettyPhoto").Include("~/Scripts/jquery.prettyPhoto.js"));

            bundles.Add(new StyleBundle("~/Content/main").Include("~/Content/css/main.css"));
            bundles.Add(new StyleBundle("~/Content/responsive").Include("~/Content/css/responsive.css"));
            bundles.Add(new StyleBundle("~/Content/prettyPhoto").Include("~/Content/css/prettyPhoto.css"));
            bundles.Add(new StyleBundle("~/Content/settings").Include("~/Content/css/settings.css"));
            bundles.Add(new StyleBundle("~/Content/turquoise").Include("~/Content/color-scheme/turquoise.css"));

            /**
             * ***************************
             * End ***********************
             * ***************************
             **/

            BundleTable.EnableOptimizations = true;
        }
    }
}