using System.Net;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public sealed class ProductsController(ISender sender) : BaseApiController
{
    [HttpGet("{id:alpha}")]
    [ProducesResponseType(typeof(GetProductByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<GetProductByIdResponse>> GetProductById([FromRoute] string id)
    {
        var query = new GetProductByIdQuery(id);
        var result = await sender.Send(query);
        return result;
    }

    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<GetAllProductsByNameResponse>), (int)HttpStatusCode.OK)]
    public async Task<IEnumerable<GetAllProductsByNameResponse>> GetProductsByName([FromQuery] string name)
    {
        var query = new GetAllProductsByNameQuery(name);
        var result = await sender.Send(query);
        return result;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetAllProductsResponse>), (int)HttpStatusCode.OK)]
    public async Task<IEnumerable<GetAllProductsResponse>> GetAllProducts()
    {
        var query = new GetAllProductsQuery();
        var result = await sender.Send(query);
        return result;
    }

    [HttpGet("types")]
    [ProducesResponseType(typeof(IEnumerable<GetAllTypesResponse>), (int)HttpStatusCode.OK)]
    public async Task<IEnumerable<GetAllTypesResponse>> GetAllProductTypes()
    {
        var query = new GetAllTypesQuery();
        var result = await sender.Send(query);
        return result;
    }  

    [HttpGet("brands")]
    [ProducesResponseType(typeof(IEnumerable<GetAllBrandsResponse>), (int)HttpStatusCode.OK)]
    public async Task<IEnumerable<GetAllBrandsResponse>> GetAllBrands()
    {
        var query = new GetAllBrandsQuery();
        var result = await sender.Send(query);
        return result;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateProductResponse), (int)HttpStatusCode.Created)]
    public async Task<ActionResult<CreateProductResponse>> CreateProduct([FromBody] CreateProductCommand request)
    {
        var result = await sender.Send(request);
        return result;
    }
    
    [HttpPut("{id:alpha}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.NoContent)]
    public async Task<ActionResult<bool>> UpdateProduct([FromRoute] string id, [FromBody] UpdateProductCommand request)
    {
        if (request.Id != id)
        {
            return BadRequest("Product ID mismatch.");
        }
        var result = await sender.Send(request);
        return result;
    }
    
    [HttpDelete("{id:alpha}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.NoContent)]
    public async Task<ActionResult<bool>> DeleteProduct([FromRoute] string id)
    {
        var request = new DeleteProductCommand(id);
        var result = await sender.Send(request);
        return result;
    }
}