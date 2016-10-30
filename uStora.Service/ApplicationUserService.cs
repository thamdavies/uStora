using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uStora.Data.Infrastructure;
using uStora.Data.Repositories;
using uStora.Model.Models;

namespace uStora.Service
{
    public interface IApplicationUserService
    {
        ApplicationUser GetUserById(string userId);
        IEnumerable<string> GetUserIdByGroupId(int id);
    }
    public class ApplicationUserService : IApplicationUserService
    {
        private IApplicationUserRepository _applicationUserRepository;
        private IUnitOfWork _unitOfWork;
        public ApplicationUserService(IApplicationUserRepository applicationUserRepository,
            IUnitOfWork unitOfWork)
        {
            _applicationUserRepository = applicationUserRepository;
            _unitOfWork = unitOfWork;
        }
        public ApplicationUser GetUserById(string userId)
        {
            try
            {
                return _applicationUserRepository.GetSingleById(userId);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<string> GetUserIdByGroupId(int id)
        {
            return _applicationUserRepository.GetUserIdByGroupId(id);
        }
    }
}
