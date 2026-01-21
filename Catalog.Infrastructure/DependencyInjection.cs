using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Persistence.Data;
using Catalog.Infrastructure.Persistence.Data.Configurations;
using Catalog.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddPersistence(services, configuration);
        AddHealthChecks(services);
        AddRepositories(services);
        
        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddSingleton<CatalogDbContext>();
        services.AddSingleton<IProductRepository, ProductsRepository>();
        services.AddSingleton<IBrandRepository, ProductsRepository>();
        services.AddSingleton<IProductTypeRepository, ProductsRepository>();
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseSettings>(
            configuration.GetSection(DatabaseSettings.SectionName));

        services.AddSingleton<IMongoClient>(sp =>
        {
            var settings = sp
                .GetRequiredService<IOptions<DatabaseSettings>>()
                .Value;

            return new MongoClient(settings.ConnectionString);
        });

        services.AddSingleton<IMongoDatabase>(sp =>
        {
            var settings = sp
                .GetRequiredService<IOptions<DatabaseSettings>>()
                .Value;

            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(settings.DatabaseName);
        });

        services.AddSingleton<MongoModelBuilder>(); 
    }

    private static void AddHealthChecks(IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddMongoDb(
                databaseNameFactory: provider => provider.GetRequiredService<IOptions<DatabaseSettings>>().Value.DatabaseName,
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "db", "mongodb" });
    }
}
