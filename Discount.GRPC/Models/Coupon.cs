namespace Discount.GRPC.Models;

public sealed class Coupon
{
    public int Id { get; set; }
    public string ProductId { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Percentage { get; set; }
}