using Catalog.Domain.Entities;

namespace Catalog.Application.Responses;

public sealed record GetProductsByBrandNameResponse(
    string Id,
    string Name,
    string Description,
    string Summary,
    decimal Price,
    Brand Brand,
    ProductType Type
    );