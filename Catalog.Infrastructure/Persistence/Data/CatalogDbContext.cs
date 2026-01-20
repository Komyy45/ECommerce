using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistence.Data.Configurations;
using Catalog.Infrastructure.Persistence.Data.Seed;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Persistence.Data;

public sealed class CatalogDbContext : MongoDbContext
{
    public IMongoCollection<Product> Products { get; }
    public IMongoCollection<ProductType> ProductTypes { get; }
    public IMongoCollection<Brand> Brands { get; }
    
    public CatalogDbContext(IMongoDatabase database, 
                            MongoModelBuilder modelBuilder, 
                            IOptions<DatabaseSettings> databaseSettingsOptions) : base(modelBuilder)
    {
        var databaseSettings = databaseSettingsOptions.Value;
        
        Products = database.GetCollection<Product>(databaseSettings.ProductsCollection);
        ProductTypes = database.GetCollection<ProductType>(databaseSettings.ProductTypesCollection);
        Brands =  database.GetCollection<Brand>(databaseSettings.BrandsCollection);

        _ = Products.SeedAsync("");
        _ = Brands.SeedAsync("");
        _ = ProductTypes.SeedAsync("");
    }
}