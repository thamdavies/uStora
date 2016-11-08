using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using uStora.Model.Models;
using uStora.Service;
using uStora.Web.Models;

namespace uStora.Web.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }
        
        public ActionResult Index(int? page, string searchString)
        {
            var wishlists = Mapper.Map<IEnumerable<Wishlist>, IEnumerable<WishlistViewModel>>(_wishlistService.GetAll(searchString));
            return View(wishlists);
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