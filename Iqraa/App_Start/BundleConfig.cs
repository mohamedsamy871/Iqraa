using System.Web;
using System.Web.Optimization;

namespace Iqraa
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
           bundles.Add(new ScriptBundle("~/bundles/GeneralScripts").Include(
                         "~/Scripts/jquery.min.js",
                         
                         "~/Scripts/bootstrap.js",
                        "~/Scripts/popper.min.js",
                        
                        "~/Scripts/bootstrap.bundle.min.js",
                        "~/Scripts/all.min.js"
                        ));
            bundles.Add(new StyleBundle("~/bundles/GeneralStyles").Include(
            "~/Content/jquery.mCustomScrollbar.min.css",
            "~/Content/bootstrap.min.css",
            
            "~/Content/owl.carousel.min.css",
            "~/Content/owl.theme.default.min.css",
            "~/Content/all.min.css",
            "~/Content/style.css",
            "~/Content/responsive.css"
          ));
            bundles.Add(new StyleBundle("~/bundles/Admin").Include(
           "~/Content/admin.css"
           ));
        }
    }
}
