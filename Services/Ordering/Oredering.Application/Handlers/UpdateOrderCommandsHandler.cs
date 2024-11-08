using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Application.Extensions;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class UpdateOrderCommandsHandler : IRequestHandler<UpdateOrderCommands, Unit>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateOrderCommandsHandler> _logger;

    public UpdateOrderCommandsHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<UpdateOrderCommandsHandler> logger)
    {
        this._orderRepository = orderRepository;
        this._mapper = mapper;
        this._logger = logger;
    }
    public async Task<Unit> Handle(UpdateOrderCommands request, CancellationToken cancellationToken)
    {
        var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
        if(orderToUpdate == null)
            throw new OrderNotFoundException(nameof(Order), request.Id);
        _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommands), typeof(Order));
        await _orderRepository.UpdateAsync(orderToUpdate);
        _logger.LogInformation($"Order {orderToUpdate.Id} is successfully updated.");
        return Unit.Value;
    }
}
