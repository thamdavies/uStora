using System;
using System.Web.Mvc;
using uStora.Web.Models;

namespace uStora.Web.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetNotificationFeedbacks()
        {
            var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
            NotificationComponent notiComponent = new NotificationComponent();
            var list = notiComponent.GetFeedbacks(notificationRegisterTime);
            Session["LastUpdate"] = DateTime.Now;
            return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}