using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries;

public sealed record GetBasketQuery(string Id) : IRequest<BasketResponse>;