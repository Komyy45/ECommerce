using MediatR;

namespace Ordering.Application.Features.Commands.DeleteOrder;

public sealed record DeleteOrderCommand(string Id) : IRequest;