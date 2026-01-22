using Catalog.Domain.Common;
using Catalog.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Catalog.Infrastructure.Persistence.Data.Configurations;

public sealed class BrandConfigurations
    : IMongoEntityConfiguration<Brand>
{
    public void Configure(BsonClassMap<Brand> builder)
    {

        builder.AutoMap();

        builder.MapMember(x => x.Name)
            .SetElementName("name")
            .SetIsRequired(true);
    }
}