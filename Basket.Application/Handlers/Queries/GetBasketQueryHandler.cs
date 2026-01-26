using AutoMapper;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Domain.Repositories;
using discount.grpc.protos;
using MediatR;
using Grpc.Core;

namespace Basket.Application.Handlers.Queries;

public sealed class GetBasketQueryHandler(
    DiscountService.DiscountServiceClient discountServiceClient,
    IMapper mapper,
    IBasketRepository basketRepository)
    : IRequestHandler<GetBasketQuery, BasketResponse>
{
    public async Task<BasketResponse> Handle(
        GetBasketQuery request,
        CancellationToken cancellationToken)
    {
        var basket = await basketRepository.Get(request.Id);

        if (basket is null)
            return new BasketResponse(request.Id, []);

        var responseItems = new List<BasketItemResponse>();

        foreach (var item in basket.Items)
        {
            var responseItem = mapper.Map<BasketItemResponse>(item);

            try
            {
                var coupon = await discountServiceClient.GetDiscountAsync(
                    new GetDiscountRequest { ProductId = item.ProductId },
                    cancellationToken: cancellationToken);

                if (coupon is not null && coupon.Percentage > 0)
                {
                    responseItem = responseItem with
                    {
                        UnitPrice = responseItem.UnitPrice -
                                    (responseItem.UnitPrice * coupon.Percentage / 100m)
                    };
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
            }
            catch (RpcException)
            {
            }

            responseItems.Add(responseItem);
        }

        return new BasketResponse(basket.Id, responseItems);
    }
}