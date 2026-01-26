namespace Basket.Application.Responses;

public sealed record BasketResponse(
    string Id,
    IEnumerable<BasketItemResponse> Items      
    );