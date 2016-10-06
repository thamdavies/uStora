using AutoMapper;
using uStora.Model.Models;
using uStora.Service;
using uStora.Web.Models;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using uStora.Common;

namespace uStora.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        IBrandService _brandService;
        ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService,
            ICommonService commonService, IProductService productService,
            IBrandService brandService)
        {
            this._productCategoryService = productCategoryService;
            this._productService = productService;
            this._commonService = commonService;
            this._brandService = brandService;
        }

        public ActionResult Index()
        {
            var listSlide = _commonService.GetSlides();
            var slideVm = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(listSlide);

            var lastestProducts = _productService.GetLastest(3);
            var listProducts = _productService.GetLastest(_productService.GetAll().Count());
            var topSaleProducts = _productService.GetTopSales(3);
            var topViews = _productService.GetTopView(3);
            var brands = _brandService.GetActivedBrand("");

            var brandVm = Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(brands);
            var listProductsVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listProducts);
            var lastestProductsVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProducts);
            var topSaleProductsVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProducts);
            var topViewsVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topViews);

            var homeVm = new HomeViewModel();
            homeVm.Slides = slideVm;
            homeVm.Brands = brandVm;
            homeVm.Products = listProductsVm;
            homeVm.TopViews = topViewsVm;
            homeVm.LatestProducts = lastestProductsVm;
            homeVm.TopSaleProducts = topSaleProductsVm;

            return View(homeVm);
        }


        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
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