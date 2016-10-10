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

            //products by tag
            routes.MapRoute(
               name: "Products by tag",
               url: "products/tags-{tagId}.htm",
               defaults: new { controller = "Product", action = "ProductsByTag", tagId = UrlParameter.Optional },
               namespaces: new string[] { "uStora.Web.Controllers" }
           );

            routes.MapRoute(
                name: "Product category",
                url: "category/{alias}-{id}.htm",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "uStora.Web.Controllers" }
            );
            //Detail
            routes.MapRoute(
                name: "Product Detail",
                url: "product/{alias}-{id}.htm",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "uStora.Web.Controllers" }
            );
            //search
            routes.MapRoute(
               name: "Search",
               url: "search.htm",
               defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
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
            //register member
            routes.MapRoute(
               name: "Register",
               url: "register.htm",
               defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
               namespaces: new string[] { "uStora.Web.Controllers" }
           );
            //login
            routes.MapRoute(
               name: "Login client",
               url: "login.htm",
               defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
               namespaces: new string[] { "uStora.Web.Controllers" }
           );
            //logout
            routes.MapRoute(
               name: "Logout client",
               url: "logout.htm",
               defaults: new { controller = "Account", action = "LogOut", id = UrlParameter.Optional },
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