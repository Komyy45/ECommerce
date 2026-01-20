using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Persistence.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Persistence.Repositories;

public sealed class ProductsRepository(CatalogDbContext context) : IProductRepository, IBrandRepository, IProductTypeRepository
{
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await context.Products.Find(_ => true).ToListAsync();
    }

    public async Task<Product> GetProductById(string id)
    {
        return await context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Product> Create(Product product)
    {
        await context.Products.InsertOneAsync(product);
        return product;
    }

    public async Task<bool> Update(Product product)
    {
        var result = await context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);

        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> Delete(string id)
    {
        
        var result = await context.Products.DeleteOneAsync(p => p.Id == id);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<IEnumerable<Product>> GetProductsByBrandName(string name)
    {
        return await context.Products.Find(p => p.Brand.Name == name).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByTypeName(string name)
    {
        return await context.Products.Find(p => p.Type.Name == name).ToListAsync();
    }

    public async Task<IEnumerable<Brand>> GetAllBrands()
    {
        return await context.Brands.Find(_ => true).ToListAsync();
    }

    public async Task<IEnumerable<ProductType>> GetAllTypes()
    {
        return await context.ProductTypes.Find(_ => true).ToListAsync();
    }
}