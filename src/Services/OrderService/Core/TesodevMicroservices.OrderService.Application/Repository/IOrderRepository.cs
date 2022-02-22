using System;
using TesodevMicroservices.Core.Repository;
using TesodevMicroservices.OrderService.Domain.Entity;

namespace TesodevMicroservices.OrderService.Application.Repository
{
    public interface IOrderRepository : IGenericRepository<Order, Guid>
    {
        
    }
}