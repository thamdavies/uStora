using System.Net;
using System.Net.Http;
using System.Web.Http;
using uStora.Service;
using uStora.Web.Infrastructure.Core;

namespace uStora.Web.Api
{
    [Authorize]
    [RoutePrefix("api/statistic")]
    public class StatisticController : ApiControllerBase
    {
        private IStatisticService _statisticService;

        public StatisticController(IErrorService errorService,
            IStatisticService statisticService) : base(errorService)
        {
            _statisticService = statisticService;
        }

        [Route("getrevenue")]
        [Authorize(Roles = "ViewUser")]
        public HttpResponseMessage GetRevenue(HttpRequestMessage request, string fromDate, string toDate)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _statisticService.GetRevenueStatistic(fromDate, toDate);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }
    }
}