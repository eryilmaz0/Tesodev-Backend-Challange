using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TesodevMicroservices.OrderService.Application.Repository;
using TesodevMicroservices.OrderService.Domain.Entity;

namespace TesodevMicroservices.OrderService.Infrastructure.Repository.EntityFramework
{
    public class MockOrderRepository : IOrderRepository
    {
        private readonly bool returnSuccess;


        public MockOrderRepository(bool returnSuccess)
        {
            this.returnSuccess = returnSuccess;
        }


        public ICollection<Order> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            return new List<Order>()
            {
                new()
                {
                    CustomerId = Guid.NewGuid(),
                    Quantity = 1,
                    Price = 100,
                    Status = "Waiting",
                    Address = new() { AddressLine = "Address", City = "City", Country = "Country", CityCode = 34 },
                    Product = new() { Id = Guid.NewGuid(), Name = "Product", ImageUrl = "ProductImage.jpg" },
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new()
                {
                    CustomerId = Guid.NewGuid(),
                    Quantity = 1,
                    Price = 100,
                    Status = "Waiting",
                    Address = new() { AddressLine = "Address", City = "City", Country = "Country", CityCode = 34 },
                    Product = new() { Id = Guid.NewGuid(), Name = "Product", ImageUrl = "ProductImage.jpg" },
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new()
                {
                    CustomerId = Guid.NewGuid(),
                    Quantity = 1,
                    Price = 100,
                    Status = "Waiting",
                    Address = new() { AddressLine = "Address", City = "City", Country = "Country", CityCode = 34 },
                    Product = new() { Id = Guid.NewGuid(), Name = "Product", ImageUrl = "ProductImage.jpg" },
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
        }

        public Order Get(Expression<Func<Order, bool>> filter)
        {
            if (returnSuccess)
                return new()
                {
                    CustomerId = Guid.NewGuid(),
                    Quantity = 1,
                    Price = 100,
                    Status = "Waiting",
                    Address = new() { AddressLine = "Address", City = "City", Country = "Country", CityCode = 34 },
                    Product = new() { Id = Guid.NewGuid(), Name = "Product", ImageUrl = "ProductImage.jpg" },
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

            return null;

        }

        public Guid Insert(Order entity)
        {
            return Guid.NewGuid();
        }

        public bool Update(Order entity)
        {
            return returnSuccess;
        }

        public bool Delete(Order entity)
        {
            return returnSuccess;
        }
    }
}