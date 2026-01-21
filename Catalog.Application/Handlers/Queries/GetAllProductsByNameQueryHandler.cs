using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Queries;

public sealed class GetAllProductsByNameQueryHandler(IProductRepository productRepository, IMapper mapper)
: IRequestHandler<GetAllProductsByNameQuery, IEnumerable<GetAllProductsByNameResponse>>
{
    public async Task<IEnumerable<GetAllProductsByNameResponse>> Handle(GetAllProductsByNameQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllProductsByName(request.Name);

        var response = mapper.Map<List<GetAllProductsByNameResponse>>(products);

        return response;
    }
}