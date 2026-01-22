namespace Catalog.Domain.Specs;

public sealed record PaginatedSpecParams
{
    public const int MaxPageSize = 80;

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string Sort { get; set; } = default!;
}