using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Responses;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Features.Commands.UpdateOrder;

public sealed class UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<UpdateOrderCommandHandler> logger)
    : IRequestHandler<UpdateOrderCommand, OrderResponse>
{
    public Task<OrderResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = mapper.Map<Order>(request);
        orderRepository.Update(order);
        logger.LogInformation($"Order with id: {order.Id} has been updated successfully!");
        return Task.FromResult(mapper.Map<OrderResponse>(order));
    }
}