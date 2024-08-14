using System;
using AutoMapper;
using Catalgo.Application.Mappers;
using Catalgo.Application.Queries;
using Catalgo.Application.Responses;
using Catalog.Core;
using MediatR;

namespace Catalgo.Application.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {

        Product product = await _productRepository.GetProductById(request.Id);
        ProductResponse productResponse = ProductMapper.Mapper.Map<Product, ProductResponse>(product);
        return productResponse;
    }
}
