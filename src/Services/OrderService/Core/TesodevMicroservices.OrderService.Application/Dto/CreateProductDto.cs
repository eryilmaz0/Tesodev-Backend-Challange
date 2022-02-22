using System;

namespace TesodevMicroservices.OrderService.Application.Dto
{
    public class CreateProductDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}