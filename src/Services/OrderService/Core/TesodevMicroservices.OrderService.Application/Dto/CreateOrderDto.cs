using System;
using TesodevMicroservices.OrderService.Domain.OwnedEntity;

namespace TesodevMicroservices.OrderService.Application.Dto
{
    public class CreateOrderDto
    {
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public CreateAddressDto Address { get; set; }
        public CreateProductDto Product { get; set; }
    }
}