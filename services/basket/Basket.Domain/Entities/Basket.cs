namespace Basket.Domain.Entities;

public sealed class Basket
{
    public string Id { get; set; } = default!;
    public IEnumerable<BasketItem> Items { get; set; } = default!;
}