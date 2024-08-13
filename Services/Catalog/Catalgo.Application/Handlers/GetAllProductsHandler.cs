using System;
using Catalgo.Application.Mappers;
using Catalgo.Application.Queries;
using Catalgo.Application.Responses;
using Catalog.Core;
using MediatR;

namespace Catalgo.Application.Handlers;


public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponse>>
{
    private readonly IProductRepository _productRepository; // To have acceses to the methods that get all dataqueris

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    public async Task<IList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> productList = await _productRepository.GetProducts(); // Get data from infrestructure project 
        IList<ProductResponse> productResponseList = ProductMapper.Mapper.Map<IList<ProductResponse>>(productList);
        return productResponseList;
    }
}
