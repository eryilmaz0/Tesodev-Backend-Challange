using System;

namespace TesodevMicroservices.CustomerService.Business.RequestObject
{
    public class GetCustomerByIdRequest
    {
        public Guid CustomerId { get; set; }
    }
}