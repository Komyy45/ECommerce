using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Commands;

public sealed class DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
: IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var isDeleted = await productRepository.Delete(request.Id);

        return isDeleted;
    }
}