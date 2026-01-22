using Catalog.Domain.Common;
using Catalog.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Catalog.Infrastructure.Persistence.Data.Configurations;

public sealed class ProductConfigurations
    : IMongoEntityConfiguration<Product>
{
    public void Configure(BsonClassMap<Product> builder)
    {
        builder.AutoMap();

        builder.MapMember(x => x.Name)
            .SetElementName("name")
            .SetIsRequired(true);

        builder.MapMember(x => x.Description)
            .SetElementName("description")
            .SetIsRequired(true);

        builder.MapMember(x => x.Summary)
            .SetElementName("summary")
            .SetIsRequired(true);

        builder.MapMember(x => x.ImageFile)
            .SetElementName("imageFile")
            .SetIsRequired(true);

        builder.MapMember(x => x.Price)
            .SetElementName("price")
            .SetSerializer(new DecimalSerializer(BsonType.Decimal128))
            .SetIsRequired(true);

        builder.MapMember(x => x.Brand)
            .SetElementName("brand")
            .SetIsRequired(true);

        builder.MapMember(x => x.Type)
            .SetElementName("type")
            .SetIsRequired(true);

        builder.SetIgnoreExtraElements(true);
    }
}