using System;
using TesodevMicroservices.OrderService.Application.Repository;
using TesodevMicroservices.OrderService.Domain.Entity;
using TesodevMicroservices.OrderService.Infrastructure.Context;

namespace TesodevMicroservices.OrderService.Infrastructure.Repository.EntityFramework
{
    public class OrderRepository : GenericRepository<Order, Guid>, IOrderRepository
    {
        private readonly  ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}