using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappers;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Brand, GetAllBrandsResponse>();

        CreateMap<Product, GetAllProductsResponse>();
        
        CreateMap<ProductType, GetAllTypesResponse>();
    }    
}