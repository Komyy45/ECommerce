namespace Basket.Domain.Entities;

public sealed class BasketItem
{
    public string ProductId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}