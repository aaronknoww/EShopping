using AutoMapper;
using Catalgo.Application.Mappers;
using Catalgo.Application.Queries;
using Catalgo.Application.Responses;
using Catalog.Core;
using MediatR;

namespace Catalgo.Application.Handlers;

public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    //private readonly IMapper _mapper;

    // public GetAllBrandsHandler(IBrandRepository brandRepository, IMapper mapper)
    // {
    //     this._brandRepository = brandRepository;
    //     this._mapper = mapper;
    // }
    public GetAllBrandsHandler(IBrandRepository brandRepository)
    {
        this._brandRepository = brandRepository;
    }
    public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<ProductBrand> brandList = await _brandRepository.GetAllBrands();
        //IList<BrandResponse> brandResponseList = _mapper.Map<IList<BrandResponse>>(brandList);
        IList<BrandResponse> brandResponseList = ProductMapper.Mapper.Map<IList<ProductBrand>,IList<BrandResponse>>(brandList.ToList());
        return brandResponseList;
    }
}
