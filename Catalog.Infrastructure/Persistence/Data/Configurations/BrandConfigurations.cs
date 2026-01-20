using Catalog.Domain.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Catalog.Infrastructure.Persistence.Data.Configurations;

public sealed class BrandConfigurations : IMongoEntityConfiguration<Brand>
{
    public void Configure(BsonClassMap<Brand> builder)
    {
        builder.AutoMap();

        builder.MapIdMember(x => x.Id)
            .SetIdGenerator(ObjectIdGenerator.Instance);

        builder.MapMember(x => x.Name)
            .SetElementName("name")
            .SetIsRequired(true);
        
        builder.SetIgnoreExtraElements(true);
    }
}