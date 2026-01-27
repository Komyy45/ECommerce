using Ordering.Domain.Entities;

namespace Ordering.Domain.Repositories;

public interface IOrderRepository : IGenericRepository<Order, string>
{
    public Task<IEnumerable<Order>> GetOrdersByUsername(string username);
}