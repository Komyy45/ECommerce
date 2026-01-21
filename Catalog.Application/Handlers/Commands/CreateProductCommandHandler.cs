using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public sealed class CreateProductCommandHandler
(IMapper mapper,
    IProductRepository productRepository)

: IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request);

        var createdProduct = await productRepository.Create(product);

        var response = mapper.Map<CreateProductResponse>(createdProduct);
        
        return response;
    }
}