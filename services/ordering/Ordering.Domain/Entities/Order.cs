using Ordering.Domain.Enums;

namespace Ordering.Domain.Entities;

public sealed class Order : BaseEntity<string>
{
    public string? UserName { get; set; } = default!;
    public decimal? TotalPrice { get; set; } = default!;
    public string? FirstName { get; set; } = default!;
    public string? LastName { get; set; } = default!;
    public string? EmailAddress { get; set; } = default!;
    public string? AddressLine { get; set; } = default!;
    public string? Country { get; set; } = default!;
    public string? State { get; set; } = default!;
    public string? ZipCode { get; set; } = default!;
    public string? CardHolderName { get; set; } = default!;
    public string? CardExpiration { get; set; } = default!;
    public string? CardNumber { get; set; } = default!;
    public string? Cvv { get; set; } = default!;
    public PaymentMethod? PaymentMethod { get; set; } = default!;
}