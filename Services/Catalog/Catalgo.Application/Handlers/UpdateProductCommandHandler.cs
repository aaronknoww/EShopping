using System;
using Catalgo.Application.Commands;
using Catalgo.Application.Mappers;
using Catalog.Core;
using MediatR;

namespace Catalgo.Application.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product productEntity = ProductMapper.Mapper.Map<Product>(request);
        //if(productEntity is null)
        //   throw new ApplicationException("There is an issue with mapping while updating a product");
        await _productRepository.UpdateProduct(productEntity);
        return true;
    }
}
