namespace Catalog.Infrastructure.Persistence.Data;

public sealed class DatabaseSettings
{
    public const string SectionName = "DatabaseSettings";

    public string ConnectionString { get; init; } = default!;
    public string DatabaseName { get; init; } = default!;
    public string ProductsCollection { get; init; } = default!;
    public string ProductTypesCollection { get; init; } = default!;
    public string BrandsCollection { get; init; } = default!;
}