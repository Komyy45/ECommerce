using MongoDB.Bson.Serialization;

namespace Catalog.Infrastructure.Persistence.Data.Configurations;

public interface IMongoEntityConfiguration<T>
{
    void Configure(BsonClassMap<T> builder);
}