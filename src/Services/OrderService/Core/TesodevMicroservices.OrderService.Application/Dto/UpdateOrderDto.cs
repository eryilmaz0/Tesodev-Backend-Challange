using System;

namespace TesodevMicroservices.OrderService.Application.Dto
{
    public class UpdateOrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public UpdateAddressDto Address { get; set; }
        public UpdateProductDto Product { get; set; }
    }
}