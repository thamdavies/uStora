using uStora.Data.Infrastructure;
using uStora.Model.Models;

namespace uStora.Data.Repositories
{
    public interface ITrackOrderRepository : IRepository<TrackOrder>
    {
    }

    public class TrackOrderRepository : RepositoryBase<TrackOrder>, ITrackOrderRepository
    {
        public TrackOrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}