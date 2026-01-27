using MediatR;
using Ordering.Application.Responses;
using Ordering.Domain.Enums;

namespace Ordering.Application.Features.Commands.CreateOrder;

public sealed record CreateOrderCommand(
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
    ) : IRequest<string>;