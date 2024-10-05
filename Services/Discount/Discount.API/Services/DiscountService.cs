using System;
using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.API.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly IMediator _mediator;

    public DiscountService(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        GetDiscountQuery query = new GetDiscountQuery(request.ProductName);
        CouponModel result = await _mediator.Send(query);
        return result;
    }
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext serverCallContext)
    {
        var cmd = new CreateDiscountCommand
        {
            ProductName = request.Coupon.ProductName,
            Description = request.Coupon.Description,
            Amount = request.Coupon.Amount
        };
        return await _mediator.Send(cmd);

    }  
    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext serverCallContext)
    {
        var cmd = new UpdateDiscountCommand
        {
            Id = request.Coupon.Id,
            ProductName = request.Coupon.ProductName,
            Description = request.Coupon.Description,
            Amount = request.Coupon.Amount
        };
        return await _mediator.Send(cmd);

    }
    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext serverCallContext)
    {
        var cmd = new DeleteDiscountCommand(request.ProductName);
        var deleted = await _mediator.Send(cmd);
        return new DeleteDiscountResponse{Success = deleted};
    }  

}
