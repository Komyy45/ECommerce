using Catalog.Domain.Entities;
using Catalog.Domain.Specs;

namespace Catalog.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts(PaginatedSpecParams? specParams = null);
    Task<IEnumerable<Product>> GetAllProductsByName(string name);
    Task<int> Count();
    Task<Product> GetProductById(string id);
    Task<Product> Create(Product product);
    Task<bool> Update(Product product);
    Task<bool> Delete(string id);
    
    Task<IEnumerable<Product>> GetProductsByBrandName(string name);
    Task<IEnumerable<Product>> GetProductsByTypeName(string name);
}
