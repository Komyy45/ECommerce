using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Queries;

public sealed class GetAllProductsQueryHandler(
    IProductRepository productRepository, 
    IMapper mapper) : IRequestHandler<GetAllProductsQuery, Pagination<GetAllProductsResponse>>
{
    public async Task<Pagination<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllProducts(request.SpecParams);

        var response = mapper.Map<List<GetAllProductsResponse>>(products);

        var count = await productRepository.Count();
        
        return new Pagination<GetAllProductsResponse>(
            request.SpecParams.PageIndex,
            request.SpecParams.PageSize,
            count,
            response);
    }
}