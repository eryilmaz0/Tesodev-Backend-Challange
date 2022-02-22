using System;
using TesodevMicroservices.CustomerService.DataAccess.Interface;
using TesodevMicroservices.CustomerService.Entities.Context;
using TesodevMicroservices.CustomerService.Entities.Entity;

namespace TesodevMicroservices.CustomerService.DataAccess.Implementation.EntityFramework
{
    public class CustomerRepository : GenericRepository<Customer, Guid>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }
    }
}