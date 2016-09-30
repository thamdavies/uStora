using uStora.Data.Infrastructure;
using uStora.Model.Models;

namespace uStora.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order> { }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}