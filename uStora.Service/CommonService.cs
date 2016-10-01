using uStora.Common;
using uStora.Data.Infrastructure;
using uStora.Data.Repositories;
using uStora.Model.Models;
using System.Collections.Generic;

namespace uStora.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }

    public class CommonService : ICommonService
    {
        private IFooterRespository _footerRespository;
        private IUnitOfWork _unitOfWork;
        private ISlideRepository _slideRepository;

        public CommonService(IFooterRespository footerRespository,
            IUnitOfWork unitOfWork, ISlideRepository slideRepository)
        {
            this._footerRespository = footerRespository;
            this._unitOfWork = unitOfWork;
            this._slideRepository = slideRepository;
        }

        public Footer GetFooter()
        {
            return _footerRespository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooter);
        }


        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status == true);
        }
    }
}