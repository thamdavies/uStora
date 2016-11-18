using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using uStora.Web.Mappings;
using uStora.Web.Models;

namespace uStora.Web
{
    public class MvcApplication : HttpApplication
    {
        private string con = ConfigurationManager.ConnectionStrings["uStoraConnection"].ConnectionString;
        protected void Application_Start()
        {
            SqlDependency.Start(con);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfiguration.Configure();
            
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            NotificationComponent notiComponent = new NotificationComponent();
            var currentTime = DateTime.Now;
            HttpContext.Current.Session["FeedbackTime"] = currentTime;
            HttpContext.Current.Session["UserTime"] = currentTime;
            notiComponent.RegisterNotification(currentTime);
        }
        protected void Application_End()
        {
            SqlDependency.Stop(con);
        }
    }
}