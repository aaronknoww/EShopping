using System;
using Discount.Application.Queries;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, CouponModel>
{
    private readonly IDiscountRepository _discountRepository;

    public GetDiscountQueryHandler(IDiscountRepository discountRepository)
    {
        this._discountRepository = discountRepository;
    }
    public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = await _discountRepository.GetDiscount(request.ProductName);
        if (coupon == null)
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount for Product Name = {request.ProductName} not found"));
        
        var couponModel = new CouponModel{
            Id = coupon.Id,
            Description = coupon.Description,
            Amount = coupon.Amount,
            ProductName = coupon.ProductName
        };
        return couponModel;
    }
}
