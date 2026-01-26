using Catalog.Domain.Common;

namespace Catalog.Domain.Entities;

public sealed class Product : BaseEntity<string>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Summary { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Price { get; set; }

    public Brand Brand { get; set; } = default!;
    public ProductType Type { get; set; } = default!;
}