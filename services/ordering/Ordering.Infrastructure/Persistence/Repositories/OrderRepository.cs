using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;
using Ordering.Infrastructure.Persistence.Data;

namespace Ordering.Infrastructure.Persistence.Repositories;

public sealed class OrderRepository(OrderingContext context) : GenericRepository<Order, string>(context), IOrderRepository
{
    public async Task<IEnumerable<Order>> GetOrdersByUsername(string username)
    {
        return await context.Orders.Where(order => order.UserName == username).ToListAsync();
    }
}