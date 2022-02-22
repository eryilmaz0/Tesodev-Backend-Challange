using System;
using TesodevMicroservices.Core.Repository;
using TesodevMicroservices.CustomerService.Entities.Entity;

namespace TesodevMicroservices.CustomerService.DataAccess.Interface
{
    public interface ICustomerRepository : IGenericRepository<Customer, Guid>
    {
        
    }
}