using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Domain.Specs;
using Catalog.Infrastructure.Persistence.Data;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Persistence.Repositories;

public sealed class ProductsRepository(CatalogDbContext context) : IProductRepository, IBrandRepository, IProductTypeRepository
{
    public async Task<IEnumerable<Product>> GetAllProducts(PaginatedSpecParams? specParams = null)
    {
        var query = context.Products.Find(_ => true);

        if (specParams is null)
            return await query.ToListAsync();

        SortDefinition<Product> sort = Builders<Product>.Sort.Combine();

        if (!string.IsNullOrEmpty(specParams.Sort))
        {
            sort = specParams.Sort switch
            {
                "priceDesc" => Builders<Product>.Sort.Descending(p => p.Price),
                "nameAsc"   => Builders<Product>.Sort.Ascending(p => p.Name),
                "nameDesc"  => Builders<Product>.Sort.Descending(p => p.Name),
                _           => Builders<Product>.Sort.Ascending(p => p.Price)
            };
        }

        return await query
            .Sort(sort)
            .Skip((specParams.PageIndex - 1) * specParams.PageSize)
            .Limit(specParams.PageSize)
            .ToListAsync();
    }

    
    public async Task<IEnumerable<Product>> GetAllProductsByName(string name)
    {
        return await context.Products.Find(p => p.Name == name).ToListAsync();
    }

    public async Task<int> Count()
    {
        return (int)await context.Products.CountDocumentsAsync(_ => true);
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