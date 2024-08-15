using Catalgo.Application.Commands;
using Catalgo.Application.Mappers;
using Catalgo.Application.Responses;
using Catalog.Core;
using MediatR;

namespace Catalgo.Application.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // a new product comes from the request and the mapper convert to a Product entity in order to insert into 
        // the data base or repository
        Product productEntity = ProductMapper.Mapper.Map<Product>(request);
        if(productEntity is null)
           throw new ApplicationException("There is an issue with mapping while creating new product");

        Product newProduct = await _productRepository.CreateProduct(productEntity);
        ProductResponse ProductResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
        return ProductResponse;
    }
}
