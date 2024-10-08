using System;
using Basket.Application.Commands;
using Basket.Application.GrpcService;
using Basket.Application.Mappers;
using Basket.Application.ResponsesDto;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class CreateShoppingCartHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
{
    private readonly IBasketRepository _basketRepository;
    private readonly DiscountGrpcService _discountGrpcService;

    public CreateShoppingCartHandler(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService)
    {
        this._basketRepository = basketRepository;
        this._discountGrpcService = discountGrpcService;
    }
    public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
    {
        foreach (var item in request.Items)
        {
            var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
            item.Price -= coupon.Amount;
        }
        var shoppingCart = await _basketRepository.UpdateBasket(new ShoppingCart
        {
            UserName = request.UserName,            
            Items = request.Items
        });
        var shoppingCartResponse = BasketMapper.Mapper.Map<ShoppingCartResponse>(shoppingCart);
        return shoppingCartResponse;

    }

}
