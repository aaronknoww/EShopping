using System;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Application.Extensions;
using Ordering.Application.Responses;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger _logger;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, ILogger logger)
    {
        this._orderRepository = orderRepository;
        this._logger = logger;
    }
    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);
        if(orderToDelete == null)
            throw new OrderNotFoundException(nameof(Core.Entities.Order), request.Id);
        await _orderRepository.DeleteAsync(orderToDelete);
        _logger.LogInformation($"Order with {request.Id} is deleted succesfully");
        return Unit.Value;
    }
}
