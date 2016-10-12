using uStora.Data.Infrastructure;
using uStora.Model.Models;

namespace uStora.Data.Repositories
{
    public interface IApplicationGroupRepository : IRepository<ApplicationGroup>
    {
    }

    public class ApplicationGroupRepository : RepositoryBase<ApplicationGroup>, IApplicationGroupRepository
    {
        public ApplicationGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}