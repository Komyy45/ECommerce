using MongoDB.Bson.Serialization;

namespace Catalog.Infrastructure.Persistence.Data.Configurations;

public class MongoModelBuilder
{
    public void ApplyConfiguration<T>(
        IMongoEntityConfiguration<T> configuration)
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
        {
            BsonClassMap.RegisterClassMap<T>(configuration.Configure);
        }
    }
}