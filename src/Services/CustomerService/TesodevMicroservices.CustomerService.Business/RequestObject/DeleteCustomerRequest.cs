using System;

namespace TesodevMicroservices.CustomerService.Business.RequestObject
{
    public class DeleteCustomerRequest
    {
        public Guid CustomerId { get; set; }
    }
}