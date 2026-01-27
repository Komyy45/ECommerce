using AutoMapper;
using Ordering.Application.Features.Commands.CreateOrder;
using Ordering.Application.Features.Commands.UpdateOrder;
using Ordering.Application.Responses;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mapper;

public sealed class OrderingProfile : Profile
{
    public OrderingProfile()
    {
        CreateMap<Order, OrderResponse>().ReverseMap();
        CreateMap<CreateOrderCommand, Order>();
        CreateMap<UpdateOrderCommand, Order>();
    }
}