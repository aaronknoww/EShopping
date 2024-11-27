using AutoMapper;
using EventBus.Messages.Common;
using Ordering.Application.Commands;
using Ordering.Application.Responses;
using Ordering.Core.Entities;

namespace Ordering.Application.Mappers;

public class OrderingMappingProfile : Profile
{
    public OrderingMappingProfile()
    {
       CreateMap<Order, OrderResponse>().ReverseMap();
       CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
       CreateMap<Order, UpdateOrderCommands>().ReverseMap();
       CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap(); 
    }

}
