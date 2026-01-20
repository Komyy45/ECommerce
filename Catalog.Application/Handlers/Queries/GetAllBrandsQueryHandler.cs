using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Queries;

public sealed class GetAllBrandsQueryHandler(
    IBrandRepository brandsRepository,
     IMapper mapper) : IRequestHandler<GetAllBrandsQuery, IEnumerable<GetAllBrandsResponse>>
{
    public async Task<IEnumerable<GetAllBrandsResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await brandsRepository.GetAllBrands();

        var response = mapper.Map<List<GetAllBrandsResponse>>(brands);
       
        return response;
    }
}