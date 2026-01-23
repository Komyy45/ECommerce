using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Commands;

public sealed record UpdateBasketCommand(
    string Id,
    IEnumerable<BasketItemResponse> Items    
    ) : IRequest<BasketResponse>;