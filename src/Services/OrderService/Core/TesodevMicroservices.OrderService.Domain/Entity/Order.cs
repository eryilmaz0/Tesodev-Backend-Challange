using System;
using TesodevMicroservices.Core.Entity.Base;
using TesodevMicroservices.Core.Entity.Child;
using TesodevMicroservices.OrderService.Domain.OwnedEntity;

namespace TesodevMicroservices.OrderService.Domain.Entity
{
    public class Order : EntityBase<Guid>
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }
    }
}