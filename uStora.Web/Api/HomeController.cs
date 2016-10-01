using uStora.Service;
using uStora.Web.Infrastructure.Core;
using System.Web.Http;

namespace uStora.Web.API
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        private IErrorService _errorService;

        public HomeController(IErrorService errorService)
            : base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Chào mừng bạn đến với uStoraShop";
        }
    }
}