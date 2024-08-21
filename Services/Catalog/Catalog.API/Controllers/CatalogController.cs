using System;
using System.Net;
using Catalgo.Application.Commands;
using Catalgo.Application.Queries;
using Catalgo.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class CatalogController : ApiController
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator) => this._mediator = mediator;
    
    [HttpGet]
    [Route("[action]/{id}", Name = "GetProductById")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<ProductResponse>> GetProductById(string id)
    {
        GetProductByIdQuery query = new GetProductByIdQuery(id);
        ProductResponse result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("[action]/{productName}", Name = "GetProductByName")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductByName(string productName)
    {
        GetProductByNameQuery query = new GetProductByNameQuery(productName);
        IList<ProductResponse> result = await _mediator.Send(query);
        return Ok(result);
    }

     [HttpGet]
    [Route("[action]/{brand}", Name = "GetProductByBrand")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductByBrand(string brand)
    {
        GetProductByBrandQuery query = new GetProductByBrandQuery(brand);
        IList<ProductResponse> result = await _mediator.Send(query);
        return Ok(result);
    }


    [HttpGet]
    [Route("GetAllProducts")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts()
    {
        GetAllProductsQuery query = new GetAllProductsQuery();
        IList<ProductResponse> result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllBrands")]
    [ProducesResponseType(typeof(IList<BrandResponse>), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IList<BrandResponse>>> GetAllBrands()
    {
        GetAllBrandsQuery query = new GetAllBrandsQuery();
        IList<BrandResponse> result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllTypes")]
    [ProducesResponseType(typeof(IList<TypeResponse>), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IList<TypeResponse>>> GetAllTypes()
    {
        GetAllTypesQuery query = new GetAllTypesQuery();
        IList<TypeResponse> result = await _mediator.Send(query);
        return Ok(result);
    }


    // COMMANDS

    [HttpPost]
    [Route("CreateProduct")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand productCommand)
    {
        ProductResponse result = await _mediator.Send<ProductResponse>(productCommand);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}",Name = "DeleteProductById")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteProdcutById(string id)
    {
        DeleteProductByIdCommand command = new DeleteProductByIdCommand(id);
        bool result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [Route("UpdateProduct")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand productCommand)
    {
        bool result = await _mediator.Send<bool>(productCommand);
        return Ok(result);
    }
    

    


}
