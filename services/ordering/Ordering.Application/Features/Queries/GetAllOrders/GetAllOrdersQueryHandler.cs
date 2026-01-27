using AutoMapper;
using MediatR;
using Ordering.Application.Responses;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Features.Queries.GetAllOrders;

public sealed class GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderResponse>>
{
    public async Task<IEnumerable<OrderResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
       var orders = await orderRepository.GetAll();
       var response = mapper.Map<List<OrderResponse>>(orders);
       return response;
    }
}