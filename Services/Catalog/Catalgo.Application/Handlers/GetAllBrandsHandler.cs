using System;
using Amazon.Runtime.Internal;
using AutoMapper;
using Catalgo.Application.Queries;
using Catalgo.Application.Responses;
using Catalog.Core;
using MediatR;

namespace Catalgo.Application.Handlers;

public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetAllBrandsHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        this._brandRepository = brandRepository;
        this._mapper = mapper;
    }
    public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<ProductBrand> brandList = await _brandRepository.GetAllBrands();
        IList<BrandResponse> brandResponseList = _mapper.Map<IList<BrandResponse>>(brandList);
        return brandResponseList;
    }
}
