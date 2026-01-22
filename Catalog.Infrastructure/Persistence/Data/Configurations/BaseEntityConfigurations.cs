using Catalog.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Catalog.Infrastructure.Persistence.Data.Configurations;

public sealed class BaseEntityConfiguration : IMongoEntityConfiguration<BaseEntity<string>>
{
    public void Configure(BsonClassMap<BaseEntity<string>> builder)
    {
        builder.MapIdProperty(x => x.Id)
            .SetIdGenerator(StringObjectIdGenerator.Instance)
            .SetSerializer(new StringSerializer(BsonType.ObjectId));
    }
}