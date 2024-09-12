using System;
using Basket.Application.ResponsesDto;
using MediatR;

namespace Basket.Application.Commands;

public class DeleteBasketByUserNameCommand : IRequest<Unit>
{
    public string UserName { get; set; }
    public DeleteBasketByUserNameCommand(string userName)
    {
        UserName = userName;
    }

}
