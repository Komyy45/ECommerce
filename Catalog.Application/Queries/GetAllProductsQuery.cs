using Catalog.Application.Responses;
using Catalog.Domain.Specs;
using MediatR;

namespace Catalog.Application.Queries;

public sealed record GetAllProductsQuery(PaginatedSpecParams SpecParams) : IRequest<Pagination<GetAllProductsResponse>>;