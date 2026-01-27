using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Features.Commands.CreateOrder;

public sealed class CreateOrderCommandHandler (IOrderRepository orderRepository, IMapper mapper, ILogger<CreateOrderCommand> logger)
    : IRequestHandler<CreateOrderCommand, string>
{
    public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = mapper.Map<Order>(request);
        var createdOrder = await orderRepository.Add(order);
        logger.LogInformation($"Order with id: {createdOrder.Id} has been created successfully!");
        return createdOrder.Id;
    }
}