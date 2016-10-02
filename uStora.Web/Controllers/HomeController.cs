using AutoMapper;
using uStora.Model.Models;
using uStora.Service;
using uStora.Web.Models;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace uStora.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService,
            ICommonService commonService, IProductService productService)
        {
            this._productCategoryService = productCategoryService;
            this._productService = productService;
            this._commonService = commonService;
        }

        [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            var listSlide = _commonService.GetSlides();
            var slideVm = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(listSlide);

            //var lastestProducts = _productService.GetLastest(3);
            //var topSaleProducts = _productService.GetTopSales(3);

            //var lastestProductsVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProducts);
            //var topSaleProductsVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProducts);

            var homeVm = new HomeViewModel();
            homeVm.Slides = slideVm;
            //homeVm.LatestProducts = lastestProductsVm;
            //homeVm.TopSaleProducts = topSaleProductsVm;

            return View(homeVm);
        }


        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll().ToList();
            var listProductCategoryVm = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryVm);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerVm = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerVm);
        }
    }
}