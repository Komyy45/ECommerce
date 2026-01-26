using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public sealed class UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request);

        var isUpdated = await productRepository.Update(product);

        return isUpdated;
    }
}