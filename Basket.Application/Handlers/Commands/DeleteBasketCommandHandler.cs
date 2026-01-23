using AutoMapper;
using Basket.Application.Commands;
using Basket.Domain.Repositories;
using MediatR;

namespace Basket.Application.Handlers.Commands;

public sealed class DeleteBasketCommandHandler(
    IBasketRepository basketRepository
    ) : IRequestHandler<DeleteBasketCommand>
{
    public async Task Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        await basketRepository.Delete(request.Id);
    }
}