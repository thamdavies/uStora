using AutoMapper;
using Microsoft.AspNet.Identity;
using MvcPaging;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using uStora.Common;
using uStora.Model.Models;
using uStora.Service;
using uStora.Web.App_Start;
using uStora.Web.Infrastructure.Extensions;
using uStora.Web.Models;

namespace uStora.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IProductService _productService;
        private IOrderService _orderService;
        private ApplicationUserManager _userManager;

        public ShoppingCartController(IProductService productService,
            ApplicationUserManager userManager, IOrderService orderService)
        {
            _productService = productService;
            _userManager = userManager;
            _orderService = orderService;
        }

        // GET: ShoppingCart
        public ActionResult Index(string searchString, int? page)
        {
            if (Session[CommonConstants.ShoppingCartSession] == null)
            {
                Session[CommonConstants.ShoppingCartSession] = new List<ShoppingCartViewModel>();
            }
            var cart = new ShoppingCartViewModel();
            int defaultPageSize = int.Parse(ConfigHelper.GetByKey("pageSizeAjax"));
            CommonController common = new CommonController(_productService);
            int currentPageIndex = page.HasValue ? page.Value : 1;
            cart.ListProducts = common.ProductListAjax(page, searchString).ToPagedList(currentPageIndex, defaultPageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_AjaxProductList", cart.ListProducts);
            else
                return View(cart);
        }
        public JsonResult GetUserInfo()
        {
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                return Json(new
                {
                    data = user,
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        public JsonResult GetAll()
        {
            if (Session[CommonConstants.ShoppingCartSession] == null)
            {
                Session[CommonConstants.ShoppingCartSession] = new List<ShoppingCartViewModel>();
            }
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.ShoppingCartSession];

            return Json(new
            {
                status = true,
                data = cart
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(long productId)
        {
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.ShoppingCartSession];
            var product = _productService.GetByID(productId);
            if (cart == null)
            {
                cart = new List<ShoppingCartViewModel>();
            }

            if (product.Quantity == 0)
            {
                return Json(new
                {
                    status = false,
                    message = "Sản phẩm này hiện tại đang hết hàng."
                });
            }
            if (cart.Any(x => x.ProductId == productId))
            {
                foreach (var item in cart)
                {
                    if (item.ProductId == productId)
                        item.Quantity += 1;
                }
            }
            else
            {
                ShoppingCartViewModel newItem = new ShoppingCartViewModel();
                newItem.ProductId = productId;
                newItem.Product = Mapper.Map<Product, ProductViewModel>(product);
                newItem.Quantity = 1;
                cart.Add(newItem);
            }
            Session[CommonConstants.ShoppingCartSession] = cart;
            Session[CommonConstants.SelledProducts] = cart;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult Update(string cartData)
        {
            var cartViewModel = new JavaScriptSerializer().Deserialize<List<ShoppingCartViewModel>>(cartData);
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.ShoppingCartSession];
            foreach (var item in cartSession)
            {
                foreach (var jitem in cartViewModel)
                {
                    if (item.ProductId == jitem.ProductId)
                    {
                        item.Quantity = jitem.Quantity;
                    }
                }
            }

            Session[CommonConstants.ShoppingCartSession] = cartSession;

            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteItem(int productId)
        {
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.ShoppingCartSession];
            if (cartSession != null)
            {
                cartSession.RemoveAll(x => x.ProductId == productId);
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.ShoppingCartSession] = new List<ShoppingCartViewModel>();

            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult CreateOrder(string orderViewModel)
        {
            var order = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
            var orderNew = new Order();
            bool isEnough = true;
            orderNew.UpdateOrder(order);
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                orderNew.CustomerId = userId;
                orderNew.CreatedBy = User.Identity.GetUserName();
            }
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.ShoppingCartSession];
            List<OrderDetail> ordersDetail = new List<OrderDetail>();
            foreach (var item in cart)
            {
                var detail = new OrderDetail();
                detail.ProductID = item.ProductId;
                detail.Quantity = item.Quantity;
                detail.Price = item.Product.Price;
                ordersDetail.Add(detail);
                isEnough = _productService.SellingProduct(item.ProductId, item.Quantity);
            }
            if (isEnough)
            {
                _orderService.Add(orderNew, ordersDetail);
                _productService.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    message = "Sản phẩm này hiện tại đang hết hàng."
                });
            }

        }
        
        public ActionResult CheckOutSuccess()
        {
            return View();
        }

        public JsonResult GetListOrder()
        {
            var orders = _orderService.GetListOrders(User.Identity.GetUserId());
            return Json(new
            {
                data = orders,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
    }
}