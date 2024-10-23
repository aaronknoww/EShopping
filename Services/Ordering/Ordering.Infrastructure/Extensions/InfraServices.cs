using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Infrastructure.Extensions;

public static class InfraServices
{
    public static IServiceCollection AddInfraServices(this IServiceCollection servicesCollection, IConfiguration configuration)
    {
        servicesCollection.AddDbContext<OrderContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("OrderingConnectionString")));
        servicesCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        servicesCollection.AddScoped<IOrderRepository, OrderRepository>();
        return servicesCollection;
         
    }

}
