using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using uStora.Common;
using uStora.Model.Models;
using uStora.Service;
using uStora.Web.Infrastructure.Core;
using uStora.Web.Models;

namespace uStora.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(long id)
        {
            var product = _productService.GetByID(id);
            var productVm = Mapper.Map<Product, ProductViewModel>(product);
            var relatedProducts = _productService.GetRelatedProducts(id, 5);

            List<string> listImages = new JavaScriptSerializer().Deserialize<List<string>>(productVm.MoreImages);
            ViewBag.MoreImages = listImages;
            ViewBag.RelatedProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(relatedProducts);
            ViewBag.Tags = Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(_productService.GetTagsByProduct(id));
            return View(productVm);
        }

        public ActionResult Category(int id, int page = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("pageSize"));
            int totalRow = 0;
            var product = _productService.GetByCategoryIDPaging(id, page, pageSize, sort, out totalRow);
            var productVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(product);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var category = _productCategoryService.GetByID(id);
            ViewBag.Category = Mapper.Map<ProductCategory, ProductCategoryViewModel>(category);

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productVm,
                MaxPage = int.Parse(ConfigHelper.GetByKey("maxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View(paginationSet);
        }

        public JsonResult GetProductsByName(string keyword)
        {
            var product = _productService.GetProductsByName(keyword);
            return Json(new
            {
                data = product
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductsByTag(string tagId, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("pageSize"));
            int totalRow = 0;
            var product = _productService.ProductsByTag(tagId, page, pageSize, out totalRow);
            var productVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(product);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            ViewBag.Tag = Mapper.Map<Tag, TagViewModel>(_productService.GetTag(tagId));

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productVm,
                MaxPage = int.Parse(ConfigHelper.GetByKey("maxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View(paginationSet);
        }

        public ActionResult Search(string keyword, int page = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("pageSize"));
            int totalRow = 0;
            var product = _productService.GetByCategoryIDPaging(keyword, page, pageSize, sort, out totalRow);
            var productVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(product);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            ViewBag.Keyword = keyword;

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productVm,
                MaxPage = int.Parse(ConfigHelper.GetByKey("maxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View(paginationSet);
        }
    }
}