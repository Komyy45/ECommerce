namespace Catalog.Application.Responses;

public sealed record GetProductByIdResponse(
        string Id,
        string Name,
        string Description,
        string Summary,
        string ImageFile,
        decimal Price
    );