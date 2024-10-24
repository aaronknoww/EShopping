using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commands;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers;

public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger logger)
    {
        this._orderRepository = orderRepository;
        this._mapper = mapper;
        this._logger = logger;
    }
    public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        Order orderEntity = _mapper.Map<Order>(request);
        var generatedOrder = await _orderRepository.AddAsync(orderEntity);
        _logger.LogInformation($"Order {generatedOrder.Id} successfully created");
        return generatedOrder.Id;
        
    }
}
