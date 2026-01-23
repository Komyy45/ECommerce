using AutoMapper;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Domain.Repositories;
using MediatR;

namespace Basket.Application.Handlers.Queries;

public sealed class GetBasketQueryHandler(
     IMapper mapper, 
     IBasketRepository basketRepository) : IRequestHandler<GetBasketQuery, BasketResponse>
{
     public async Task<BasketResponse> Handle(GetBasketQuery request, CancellationToken cancellationToken)
     {
          var basket = await basketRepository.Get(request.Id);

          var response = mapper.Map<BasketResponse>(basket);
          
          return response;
     }
}