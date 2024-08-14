using System;
using Catalgo.Application.Mappers;
using Catalgo.Application.Queries;
using Catalgo.Application.Responses;
using Catalog.Core;
using MediatR;

namespace Catalgo.Application.Handlers;

public class GetProductByBrandHandler : IRequestHandler<GetProductByBrandQuery, IList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByBrandHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> productList = await _productRepository.GetProductByBrand(request.BrandName);
        IList<ProductResponse> productResponseList =  ProductMapper.Mapper.Map<IList<ProductResponse>>(productList);
        return productResponseList;
    }
}
