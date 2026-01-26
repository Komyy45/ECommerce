namespace Basket.Application.Responses;

public sealed record BasketItemResponse(
     string ProductId,
     string Name,
     string ImageFile,
     decimal UnitPrice,
     int Quantity
    );