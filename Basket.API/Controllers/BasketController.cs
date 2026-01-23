using System.Net;
using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

public sealed class BasketController(ISender mediator) : BaseApiController
{
    [HttpGet("{id:alpha}")]
    [ProducesResponseType(typeof(BasketResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BasketResponse>> GetBasket(string id)
    {
        var request = new GetBasketQuery(id);
        var response = await mediator.Send(request);
        return response;
    }
    
    [HttpPut("{id:alpha}")]
    [ProducesResponseType(typeof(BasketResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BasketResponse>> UpdateBasket([FromRoute] string id, [FromBody] IEnumerable<BasketItemResponse> items)
    {
        var request = new UpdateBasketCommand(id, items);
        var response = await mediator.Send(request);
        return response;
    }
    
    [HttpDelete("{id:alpha}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult<BasketResponse>> DeleteBasket([FromRoute] string id)
    {
        var request = new DeleteBasketCommand(id); 
        await mediator.Send(request);
        return NoContent();
    }
    
    
}