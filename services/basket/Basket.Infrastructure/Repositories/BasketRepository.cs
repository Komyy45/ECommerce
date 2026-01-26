using System.Text.Json;
using Basket.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.Infrastructure.Repositories;

public sealed class BasketRepository(IDistributedCache database) : IBasketRepository
{
    
    public async Task<Domain.Entities.Basket?> Get(string id)
    {
        var data = await database.GetStringAsync(id);
        
        return data is null ? null : JsonSerializer.Deserialize<Domain.Entities.Basket>(data);
    }

    public async Task<Domain.Entities.Basket> Update(Domain.Entities.Basket updatedBasket)
    {
        var data = JsonSerializer.Serialize(updatedBasket);
        
        await database.SetStringAsync(updatedBasket.Id, data);
        
        return updatedBasket;
    }

    public async Task Delete(string id)
    {
        await database.RemoveAsync(id);
    }
}