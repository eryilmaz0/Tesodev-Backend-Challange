using System;

namespace TesodevMicroservices.OrderService.Application.ViewModel
{
    public class ListOrdersViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public AddressViewModel Address { get; set; }
        public ProductViewModel Product { get; set; }
    }
}