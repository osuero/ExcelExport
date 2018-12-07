using System.Web.Optimization;

namespace PIP
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/core-css").Include(
                "~/Assets/libs/bootstrap/2.3.1/bootstrap.min.css",
                "~/Assets/css/main.css",
                "~/Assets/libs/supersized/3.2.7/css/supersized.css",
                "~/Assets/libs/supersized/3.2.7/theme/supersized.shutter.css",
                "~/Assets/libs/jquery-fancybox/2.1.4/jquery.fancybox.css",
                "~/Assets/fonts/font-icons/fonts.css",
                "~/Assets/css/shortcodes.css",
                "~/Assets/libs/bootstrap/2.3.1/bootstrap-responsive.min.css",
                "~/Assets/css/responsive.css"
                ));

            //bundles.Add(new StyleBundle("~/bundles/template-css").Include(
            //    ));

            bundles.Add(new ScriptBundle("~/bundles/core-js").Include(
                "~/Assets/libs/jquery/3.3.1/jquery-3.3.1.min.js",
                "~/Assets/libs/jquery/3.3.1/jquery-migrate-3.0.0.js",
                "~/Assets/libs/bootstrap/2.3.1/bootstrap.min.js",
                "~/Assets/libs/supersized/3.2.7/js/supersized.3.2.7.js",
                "~/Assets/libs/supersized/3.2.7/theme/supersized.shutter.min.js",
                "~/Assets/libs/jquery-waypoints/4.0.1/jquery.waypoints.min.js",
                "~/Assets/libs/jquery-waypoints/4.0.1/shortcuts/sticky.min.js",
                "~/Assets/libs/jquery-isotope/1.5.25/jquery.isotope.js",
                "~/Assets/libs/jquery-fancybox/2.1.4/jquery.fancybox.pack.js",
                "~/Assets/libs/jquery-fancybox/2.1.4/jquery.fancybox-media.js",
                "~/Assets/libs/plugins.js",
                "~/Assets/js/main.js"
                ));

            //bundles.Add(new ScriptBundle("~/bundles/template-js").Include(
            //    ));

            BundleTable.EnableOptimizations = false;
        }
    }
}