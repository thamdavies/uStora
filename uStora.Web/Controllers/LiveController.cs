using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;
using uStora.Model.Models;
using uStora.Service;
using uStora.Web.Models;

namespace uStora.Web.Controllers
{
    [Authorize]
    public class LiveController : Controller
    {
        private ITrackOrderService _trackOrderService;

        public LiveController(ITrackOrderService trackOrderService)
        {
            _trackOrderService = trackOrderService;
        }

        public ActionResult Index()
        {
            var trackOrders = Mapper.Map<IEnumerable<TrackOrder>, IEnumerable<TrackOrderViewModel>>(_trackOrderService.GetByUserId(User.Identity.GetUserId()));
            return View(trackOrders);
        }

        public JsonResult UpdateTrackOrder(string lng, string lat)
        {
            var trackOrders = _trackOrderService.GetByUserId(User.Identity.GetUserId());
            foreach (var item in trackOrders)
            {
                item.Latitude = lat;
                item.Longitude = lng;
            }
            _trackOrderService.SaveChanges();
            return Json(new
            {
                data = lat + " - " + lng,
                status = true
            });
        }
    }
}