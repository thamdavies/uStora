using uStora.Data.Infrastructure;
using uStora.Model.Models;

namespace uStora.Data.Repositories
{
    public interface IApplicationRoleRepository : IRepository<ApplicationRole>
    {
    }

    public class ApplicationRoleRepository : RepositoryBase<ApplicationRole>, IApplicationRoleRepository
    {
        public ApplicationRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}