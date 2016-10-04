using System.Web.Mvc;
using System.Web.Routing;

namespace uStora.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Product category",
                url: "category/{alias}/{id}.htm",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "uStora.Web.Controllers" }
            );
            //shop
            routes.MapRoute(
               name: "Shop",
               url: "shop.htm",
               defaults: new { controller = "Product", action = "Shop", id = UrlParameter.Optional },
               namespaces: new string[] { "uStora.Web.Controllers" }
           );
            //contact
            routes.MapRoute(
               name: "Contact",
               url: "contact.htm",
               defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "uStora.Web.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "uStora.Web.Controllers" }
            );
        }
    }
}