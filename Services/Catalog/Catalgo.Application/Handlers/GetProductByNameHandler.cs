using Catalgo.Application.Mappers;
using Catalgo.Application.Queries;
using Catalgo.Application.Responses;
using Catalog.Core;
using MediatR;

namespace Catalgo.Application.Handlers;

public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, IList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByNameHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    public async Task<IList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> productList = await _productRepository.GetProductByName(request.Name);
        IList<ProductResponse> productResponseList = ProductMapper.Mapper.Map<IList<ProductResponse>>(productList);
        return productResponseList;
    }
}
