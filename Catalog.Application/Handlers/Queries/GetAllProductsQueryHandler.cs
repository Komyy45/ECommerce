using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Queries;

public sealed class GetAllProductsQueryHandler(
    IProductRepository productRepository, 
    IMapper mapper) : IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductsResponse>>
{
    public async Task<IEnumerable<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllProducts();

        var response = mapper.Map<List<GetAllProductsResponse>>(products);
        
        return response;
    }
}