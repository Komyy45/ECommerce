using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Queries;

public sealed class GetProductsByBrandNameQueryHandler(IProductRepository  productRepository, IMapper mapper) : IRequestHandler<GetProductsByBrandNameQuery, IEnumerable<GetProductsByBrandNameResponse>>
{
    public async Task<IEnumerable<GetProductsByBrandNameResponse>> Handle(GetProductsByBrandNameQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductsByBrandName(request.BrandName);

        var response = mapper.Map<List<GetProductsByBrandNameResponse>>(products);

        return response;
    }
}