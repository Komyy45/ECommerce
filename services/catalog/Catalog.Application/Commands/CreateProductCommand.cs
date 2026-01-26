using Catalog.Application.Responses;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Commands;

public sealed record CreateProductCommand(
    string Name, 
    string Description,
    string Summary,
    decimal Price,
    Brand Brand,
    ProductType Type
    ) : IRequest<CreateProductResponse>;