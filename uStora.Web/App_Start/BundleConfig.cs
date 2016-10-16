using System.Web;
using System.Web.Optimization;

namespace uStora.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/jquery")
                .Include("~/Assets/libs/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/js/bootstrap")
               .Include("~/Assets/libs/bootstrap/dist/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/js/etalage")
              .Include("~/Assets/Client/js/jquery.etalage.min.js"));

            bundles.Add(new ScriptBundle("~/js/core").Include(
                "~/Assets/libs/jquery-ui/jquery-ui.min.js",
                "~/Assets/libs/jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.js",
                "~/Assets/Client/js/owl.carousel.min.js",
                "~/Assets/Client/js/jquery.sticky.js",
                "~/Assets/libs/numeral/numeral.js",
                "~/Assets/libs/toastr/toastr.min.js",
                "~/Assets/Client/js/jquery.easing.1.3.min.js",
                "~/Assets/libs/jquery-ui/jquery-ui.js",
                "~/Assets/Client/js/main.js",
                "~/Assets/Client/js/search-box.js",
                "~/Assets/Client/js/cart.js",
                "~/Assets/Client/js/scroll-startstop.events.jquery.js",
                "~/Assets/Client/js/scroll.js",
                "~/Assets/Client/js/common.js",
                "~/Assets/Client/js/controllers/addToCart.js",
                "~/Assets/Client/js/bxslider.min.js",
                "~/Assets/Client/js/script.slider.js"));

            bundles.Add(new StyleBundle("~/css/core")
                .Include("~/Assets/libs/bootstrap/dist/css/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/libs/jquery-ui/themes/smoothness/jquery-ui.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/libs/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/libs/toastr/toastr.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/owl.carousel.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/style.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/etalage.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/search-box.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/customize.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/responsive.css", new CssRewriteUrlTransform()));


            BundleTable.EnableOptimizations = true;
        }
    }
}
