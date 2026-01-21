using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Commands;

public sealed record UpdateProductCommand(
    string Id,
    string Name, 
    string Description,
    string Summary,
    decimal Price,
    Brand Brand,
    ProductType Type
    ) : IRequest<bool>;