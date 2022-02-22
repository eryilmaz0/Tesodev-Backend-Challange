using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TesodevMicroservices.OrderService.Application.Proxy;
using TesodevMicroservices.OrderService.Application.Repository;
using TesodevMicroservices.OrderService.Infrastructure.Context;
using TesodevMicroservices.OrderService.Infrastructure.Proxy.CustomerServiceProxy;
using TesodevMicroservices.OrderService.Infrastructure.Repository.EntityFramework;

namespace TesodevMicroservices.OrderService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
            serviceCollection.AddTransient<ICustomerServiceProxy, CustomerServiceProxy>();
        }


        public static void AddDbContextRegistration(this IServiceCollection serviceCollection, string conString)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(conString));
        }
    }
}