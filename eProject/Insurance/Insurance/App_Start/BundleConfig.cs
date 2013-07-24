using System.Web;
using System.Web.Optimization;

namespace Insurance
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/nicescroll").Include(
                        "~/Areas/Administrator/Scripts/plugins/nicescroll/jquery.nicescroll.min.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/jquery-ui").Include(
                        "~/Areas/Administrator/Scripts/plugins/jquery-ui/jquery.ui.core.min.js",
                        "~/Areas/Administrator/Scripts/plugins/jquery-ui/jquery.ui.widget.min.js",
                        "~/Areas/Administrator/Scripts/plugins/jquery-ui/jquery.ui.mouse.min.js",
                        "~/Areas/Administrator/Scripts/plugins/jquery-ui/jquery.ui.draggable.min.js",
                        "~/Areas/Administrator/Scripts/plugins/jquery-ui/jquery.ui.resizable.min.js",
                        "~/Areas/Administrator/Scripts/plugins/jquery-ui/jquery.ui.sortable.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/touch-punch").Include(
                        "~/Areas/Administrator/Scripts/plugins/touch-punch/jquery.touch-punch.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/slimscroll").Include(
                        "~/Areas/Administrator/Scripts/plugins/slimscroll/jquery.slimscroll.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/bootstrap").Include(
                        "~/Areas/Administrator/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/vmap").Include(
                        "~/Areas/Administrator/Scripts/plugins/vmap/jquery.vmap.min.js",
                        "~/Areas/Administrator/Scripts/plugins/vmap/jquery.vmap.world.js",
                        "~/Areas/Administrator/Scripts/plugins/vmap/jquery.vmap.sampledata.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/bootbox").Include(
                        "~/Areas/Administrator/Scripts/plugins/bootbox/jquery.bootbox.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/flot").Include(
                        "~/Areas/Administrator/Scripts/plugins/flot/jquery.flot.min.js",
                        "~/Areas/Administrator/Scripts/plugins/flot/jquery.flot.bar.order.min.js",
                        "~/Areas/Administrator/Scripts/plugins/flot/jquery.flot.pie.min.js",
                        "~/Areas/Administrator/Scripts/plugins/flot/jquery.flot.resize.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/imagesLoaded").Include(
                        "~/Areas/Administrator/Scripts/plugins/imagesLoaded/jquery.imagesloaded.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/pageguide").Include(
                        "~/Areas/Administrator/Scripts/plugins/pageguide/jquery.pageguide.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/fullcalendar").Include(
                        "~/Areas/Administrator/Scripts/plugins/fullcalendar/fullcalendar.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/chosen").Include(
                        "~/Areas/Administrator/Scripts/plugins/chosen/chosen.jquery.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/select2").Include(
                        "~/Areas/Administrator/Scripts/plugins/select2/select2.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/plugins/icheck").Include(
                        "~/Areas/Administrator/Scripts/plugins/icheck/jquery.icheck.min.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/themes").Include(
                        "~/Areas/Administrator/Scripts/eakroko.min.js",
                        "~/Areas/Administrator/Scripts/application.min.js",
                        "~/Areas/Administrator/Scripts/demonstration.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/admin/Content/bootstrap").Include(
                                        "~/Areas/Administrator/Content/bootstrap.css",
                                        "~/Areas/Administrator/Content/bootstrap-responsive.css"
                                        ));

            bundles.Add(new StyleBundle("~/admin/Content/plugins").Include(
                                        "~/Areas/Administrator/Content/plugins/jquery-ui/smoothness/jquery-ui.css",
                                        "~/Areas/Administrator/Content/plugins/jquery-ui/smoothness/jquery.ui.theme.css",
                                        "~/Areas/Administrator/Content/plugins/pageguide/pageguide.css",
                                        "~/Areas/Administrator/Content/plugins/fullcalendar/fullcalendar.css",
                                        "~/Areas/Administrator/Content/plugins/fullcalendar/fullcalendar.print.css",
                                        "~/Areas/Administrator/Content/plugins/chosen/chosen.css",
                                        "~/Areas/Administrator/Content/plugins/select2/select2.css",
                                        "~/Areas/Administrator/Content/plugins/icheck/all.css"
                                        ));

            bundles.Add(new StyleBundle("~/admin/Content/style").Include("~/Areas/Administrator/Content/style.css"));

            bundles.Add(new StyleBundle("~/admin/Content/themes").Include("~/Areas/Administrator/Content/themes.css"));
            
        }
    }
}