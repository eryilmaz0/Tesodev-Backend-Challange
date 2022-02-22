using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TesodevMicroservices.CustomerService.DataAccess.Interface;
using TesodevMicroservices.CustomerService.Entities.Entity;

namespace TesodevMicroservices.CustomerService.DataAccess.Implementation.EntityFramework
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private readonly bool returnSuccess;

        public MockCustomerRepository(bool returnSuccess)
        {
            this.returnSuccess = returnSuccess;
        }

        public ICollection<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return new List<Customer>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Customer 1",
                    Email = "Customer1@gmail.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Address = new(){AddressLine = "Address", City = "City", Country = "Country", CityCode = 10}
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Customer 2",
                    Email = "Customer2@gmail.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Address = new(){AddressLine = "Address", City = "City", Country = "Country", CityCode = 10}
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Customer 3",
                    Email = "Customer3@gmail.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Address = new(){AddressLine = "Address", City = "City", Country = "Country", CityCode = 10}
                }
            };
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
           if(returnSuccess)
               return new()
               {
                   Id = Guid.NewGuid(),
                   Name = "Customer 3",
                   Email = "Customer3@gmail.com",
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now,
                   Address = new() { AddressLine = "Address", City = "City", Country = "Country", CityCode = 10 }
               };

           return null;
        }


        public Guid Insert(Customer entity)
        {
            return Guid.NewGuid();
        }

        public bool Update(Customer entity)
        {
            return returnSuccess;
        }

        public bool Delete(Customer entity)
        {
            return returnSuccess;
        }
    }
}