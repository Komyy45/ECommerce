using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public sealed record GetAllProductsByNameQuery(string Name) : IRequest<GetAllProductsByNameResponse>, IRequest<IEnumerable<GetAllProductsByNameResponse>>;