using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Features.Queries.GetAllOrders;

public sealed record GetAllOrdersQuery() : IRequest<IEnumerable<OrderResponse>>;