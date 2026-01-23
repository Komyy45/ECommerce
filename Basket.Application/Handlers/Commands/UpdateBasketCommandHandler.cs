using AutoMapper;
using Basket.Application.Commands;
using Basket.Application.Responses;
using Basket.Domain.Entities;
using Basket.Domain.Repositories;
using MediatR;

namespace Basket.Application.Handlers.Commands;

public sealed class UpdateBasketCommandHandler(IMapper mapper, IBasketRepository basketRepository) : IRequestHandler<UpdateBasketCommand, BasketResponse>
{
    public async Task<BasketResponse> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.Get(request.Id) ?? new Domain.Entities.Basket()
        {
            Id = Guid.NewGuid().ToString(),
            Items = mapper.Map<List<BasketItem>>(request.Items)
        };

        var response = await basketRepository.Update(basket);

        return mapper.Map<BasketResponse>(response);
    }
}