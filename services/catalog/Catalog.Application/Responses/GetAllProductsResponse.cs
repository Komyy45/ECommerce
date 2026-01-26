using Catalog.Domain.Entities;

namespace Catalog.Application.Responses;

public sealed record GetAllProductsResponse(
    string Id,
    string Name, 
    string Description,
    string Summary,
    decimal Price,
    Brand Brand,
    ProductType Type);