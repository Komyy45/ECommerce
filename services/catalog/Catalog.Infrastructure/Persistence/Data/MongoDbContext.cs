using System.Reflection;
using Catalog.Infrastructure.Persistence.Data.Configurations;

namespace Catalog.Infrastructure.Persistence.Data;

public abstract class MongoDbContext
{
    protected MongoDbContext(MongoModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}