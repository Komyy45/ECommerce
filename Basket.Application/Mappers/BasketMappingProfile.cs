using AutoMapper;
using Basket.Application.Responses;
using Basket.Domain.Entities;

namespace Basket.Application.Mappers;

public sealed class BasketMappingProfile : Profile
{
    public BasketMappingProfile()
    {
        CreateMap<BasketItem, BasketItemResponse>();
        CreateMap<Domain.Entities.Basket, BasketResponse>();
    }
}