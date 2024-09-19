using System.Net;
using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.ResponsesDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controller
{

    public class BasketController : ApiController
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("[action]/{userName}", Name = "GetBasketByUserName")]
        [ProducesResponseType(typeof(ShoppingCartResponse), (int) HttpStatusCode.OK)]

        public async Task<ActionResult<ShoppingCartResponse>> GetBasket(string userName)
        {
            GetBasketByUserNameQuery query = new GetBasketByUserNameQuery(userName);
            ShoppingCartResponse basket = await _mediator.Send(query);
            return Ok(basket);
        }

        [HttpPost("CreateBasket")]
        [ProducesResponseType(typeof(ShoppingCartResponse), (int) HttpStatusCode.OK)]

        public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] CreateShoppingCartCommand createShoppingCartCommand)
        {
            ShoppingCartResponse basket = await _mediator.Send(createShoppingCartCommand);
            return Ok(basket);
        }

        [HttpDelete]
        [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
        [ProducesResponseType((int) HttpStatusCode.OK)]

        public async Task<ActionResult> DeleteBasket(string userName)
        {
            var cmd = new DeleteBasketByUserNameCommand(userName);
            return Ok(await _mediator.Send(cmd)); 
        }
       


    }
}
