namespace Catalog.Application.Responses;

public sealed record Pagination<T>(
        int PageIndex,
        int PageSize,
        int Count,
        IReadOnlyList<T> Data
        );