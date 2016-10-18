using AutoMapper;
using MvcPaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uStora.Common;
using uStora.Model.Models;
using uStora.Service;
using uStora.Web.Models;

namespace uStora.Web.Controllers
{
    public class WishlistController : Controller
    {
        IProductService _productService;
        public WishlistController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index(int? page, string searchString)
        {
            return View();
        }
    }
}