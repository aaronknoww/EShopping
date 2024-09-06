using System;
using Catalgo.Application.Mappers;
using Catalgo.Application.Queries;
using Catalgo.Application.Responses;
using Catalog.Core;
using Catalog.Core.Specs;
using MediatR;

namespace Catalgo.Application.Handlers;


public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, Pagination<ProductResponse>>
{
    private readonly IProductRepository _productRepository; // To have acceses to the methods that get all dataqueris

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    public async Task<Pagination<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await _productRepository.GetProducts(request.CatalogSpecParams); // Get data from infrestructure project 
        Pagination<ProductResponse> productResponseList = ProductMapper.Mapper.Map<Pagination<ProductResponse>>(productList);
        return productResponseList;
    }
}
