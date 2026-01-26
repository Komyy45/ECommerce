using Catalog.Domain.Entities;
using MongoDB.Bson.Serialization;

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