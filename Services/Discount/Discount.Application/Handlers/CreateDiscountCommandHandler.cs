using System;
using AutoMapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Commands;

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, CouponModel>
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;

    public CreateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper)
    {
        this._discountRepository = discountRepository;
        this._mapper = mapper;
    }
    public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        Coupon coupon = _mapper.Map<Coupon>(request);
        await _discountRepository.CreateDiscount(coupon);
        CouponModel couponModel = _mapper.Map<CouponModel>(coupon);
        return couponModel;
    }
}
