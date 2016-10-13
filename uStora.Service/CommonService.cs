using uStora.Common;
using uStora.Data.Infrastructure;
using uStora.Data.Repositories;
using uStora.Model.Models;
using System.Collections.Generic;
using System;

namespace uStora.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
        IEnumerable<ApplicationUser> GetUsers(string filter);
    }

    public class CommonService : ICommonService
    {
        private IFooterRespository _footerRespository;
        private IUnitOfWork _unitOfWork;
        private ISlideRepository _slideRepository;
        IApplicationUserRepository _applicationUserRepository;

        public CommonService(IFooterRespository footerRespository,
            IUnitOfWork unitOfWork, ISlideRepository slideRepository,
            IApplicationUserRepository applicationUserRepository)
        {
            this._footerRespository = footerRespository;
            this._unitOfWork = unitOfWork;
            this._slideRepository = slideRepository;
            this._applicationUserRepository = applicationUserRepository;
        }

        public Footer GetFooter()
        {
            return _footerRespository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooter);
        }


        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status == true);
        }

        public IEnumerable<ApplicationUser> GetUsers(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                return _applicationUserRepository.GetMulti(x => x.FullName.Contains(filter));
            }
            else
            {
                return _applicationUserRepository.GetAll();
            }
        }
    }
}