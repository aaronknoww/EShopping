using Catalgo.Application.Commands;
using Catalog.Core;
using MediatR;

namespace Catalgo.Application.Handlers;

public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductByIdCommandHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
       return await _productRepository.DeleteProductId(request.Id);
    }
}
