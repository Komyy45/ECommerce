using Ordering.Domain.Enums;

namespace Ordering.Application.Responses;

public sealed record OrderResponse
(
    string Id,
    string? UserName,
    decimal? TotalPrice,
    string? FirstName,
    string? LastName,
    string? EmailAddress,
    string? AddressLine,
    string? Country,
    string? State,
    string? ZipCode,
    string? CardHolderName,
    string? CardExpiration,
    string? CardNumber,
    string? Cvv,
    PaymentMethod? PaymentMethod
);