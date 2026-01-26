namespace Basket.Domain.Repositories;

public interface IBasketRepository
{
    public Task<Entities.Basket?> Get(string id);
    public Task<Entities.Basket> Update(Entities.Basket updatedBasket);
    public Task Delete(string id);
}