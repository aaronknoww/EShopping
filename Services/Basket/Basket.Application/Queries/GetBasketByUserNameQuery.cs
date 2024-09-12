using System;
using Basket.Application.ResponsesDto;
using MediatR;

namespace Basket.Application.Queries;

public class GetBasketByUserNameQuery : IRequest<ShoppingCartResponse>
{
    public string UserName { get; set; }

    public GetBasketByUserNameQuery(string userName) => UserName = userName;


}
