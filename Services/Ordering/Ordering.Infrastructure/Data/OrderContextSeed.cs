using System;
using Azure.Identity;
using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContext> logger)
    {
        if (!orderContext.Orders.Any())
        {
            orderContext.Orders.AddRange(GetOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation($"Oredering Database: {typeof(OrderContext).Name} seeded!!");
        }
    }

    private static IEnumerable<Order> GetOrders()
    {
        return new List<Order>
        {
            new()
            {
                UserName = "aaron",
                FirstName = "Aaron",
                LastName = "Know",
                EmailAddress = "aaronsharp@gmail.com",
                AddressLine = "Juarez",
                Country = "Mexico",
                TotalPrice = 1500,
                State = "CH",
                ZipCode = "324060",
                
                CardName = "Blue",
                CardNumber = "4567981432147812",
                CreatedBy = "Aaron",
                Expiration = "12/30",
                Cvv = "876",
                PaymentMethod = 1,
                LastModifyBy = "Aaron",
                LastModifiedDate = new DateTime(),

            }
        };
    }
}
