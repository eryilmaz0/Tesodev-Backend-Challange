using System;

namespace TesodevMicroservices.OrderService.Domain.OwnedEntity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}