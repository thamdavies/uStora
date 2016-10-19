using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using uStora.Model.Models;
using uStora.Service;

namespace uStora.Web.Controllers
{
    public class WishlistController : Controller
    {
        private IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public ActionResult Index(int? page, string searchString)
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(long productId)
        {
            try
            {
                var wishlist = new Wishlist();
                wishlist.ProductId = productId;
                wishlist.UserId = User.Identity.GetUserId();
                wishlist.CreatedDate = DateTime.Now;
                wishlist.CreatedBy = User.Identity.GetUserName();
                if (!_wishlistService.CheckContains(productId))
                {
                    _wishlistService.Add(wishlist);
                    _wishlistService.SaveChanges();
                    return Json(new
                    {
                        status = 1
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = 2,
                        message = "Bạn đã thích sản phẩm này."
                    });
                }
            }
            catch
            {
                return Json(new
                {
                    status = 0
                });
            }
        }
    }
}