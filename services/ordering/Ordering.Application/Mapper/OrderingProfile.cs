using AutoMapper;
using Ordering.Application.Responses;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mapper;

public sealed class OrderingProfile : Profile
{
    public OrderingProfile()
    {
        CreateMap<Order, OrderResponse>().ReverseMap();
    }
}