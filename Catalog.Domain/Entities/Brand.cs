using Catalog.Domain.Common;

namespace Catalog.Domain.Entities;

public sealed class Brand : BaseEntity<string>
{
    public string Name { get; set; } = default!;
}