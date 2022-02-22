using System;

namespace TesodevMicroservices.OrderService.Application.ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}