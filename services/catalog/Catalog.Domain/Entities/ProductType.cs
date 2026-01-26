using Catalog.Domain.Common;

namespace Catalog.Domain.Entities;

public sealed class ProductType : BaseEntity<string>
{
    public string Name { get; set; } = default!;
}