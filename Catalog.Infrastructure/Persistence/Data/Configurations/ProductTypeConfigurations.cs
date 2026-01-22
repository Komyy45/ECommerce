using Catalog.Domain.Common;
using Catalog.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Catalog.Infrastructure.Persistence.Data.Configurations;

public sealed class ProductTypeConfigurations
    : IMongoEntityConfiguration<ProductType>
{
    public void Configure(BsonClassMap<ProductType> builder)
    {
        builder.AutoMap();

        builder.MapMember(x => x.Name)
            .SetElementName("name")
            .SetIsRequired(true);

        builder.SetIgnoreExtraElements(true);
    }
}