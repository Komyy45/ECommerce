using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Queries;

public sealed class GetAllTypesQueryHandler(IProductTypeRepository productTypeRepository, 
    IMapper mapper) : IRequestHandler<GetAllTypesQuery, IEnumerable<GetAllTypesResponse>>
{
    public async Task<IEnumerable<GetAllTypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
    {
        var types = await productTypeRepository.GetAllTypes();
        var response = mapper.Map<List<GetAllTypesResponse>>(types); 
        return response;
    }
}