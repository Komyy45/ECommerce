using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public sealed record GetProductsByBrandNameQuery(string BrandName) : IRequest<GetProductsByBrandNameResponse>, IRequest<IEnumerable<GetProductsByBrandNameResponse>>;