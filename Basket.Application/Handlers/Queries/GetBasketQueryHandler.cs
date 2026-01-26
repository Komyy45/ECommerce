using AutoMapper;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Domain.Repositories;
using discount.grpc.protos;
using Google.Protobuf.WellKnownTypes;
using MediatR;

namespace Basket.Application.Handlers.Queries;

public sealed class GetBasketQueryHandler(
     DiscountService.DiscountServiceClient discountServiceClient,
     IMapper mapper, 
     IBasketRepository basketRepository) : IRequestHandler<GetBasketQuery, BasketResponse>
{
     public async Task<BasketResponse> Handle(GetBasketQuery request, CancellationToken cancellationToken)
     {
          var basket = await basketRepository.Get(request.Id);

          List < BasketItemResponse > responseItemsList = [];

          foreach (var item in basket.Items)
          {
               var couponModel = await discountServiceClient.GetDiscountAsync(new GetDiscountRequest()
                    { ProductId = item.ProductId });

               if (couponModel is null) continue;

               var productAfterDiscount = mapper.Map<BasketItemResponse>(item);
               productAfterDiscount = productAfterDiscount with
               {
                    UnitPrice = productAfterDiscount.UnitPrice -
                                (productAfterDiscount.UnitPrice * (couponModel.Percentage / 100))
               };
               
               responseItemsList.Add(productAfterDiscount);
          }

          var response = new BasketResponse(basket.Id, responseItemsList);
          
          return response;
     }
}