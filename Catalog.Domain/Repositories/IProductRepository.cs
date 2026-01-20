using Catalog.Domain.Entities;

namespace Catalog.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(string id);
    Task<Product> Create(Product product);
    Task<bool> Update(Product product);
    Task<bool> Delete(string id);
    
    Task<IEnumerable<Product>> GetProductsByBrandName(string name);
    Task<IEnumerable<Product>> GetProductsByTypeName(string name);
}
