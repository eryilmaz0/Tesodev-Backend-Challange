using System.Collections;
using System.Collections.Generic;
using TesodevMicroservices.CustomerService.Entities.Entity;

namespace TesodevMicroservices.CustomerService.Business.ResponseObject
{
    public class GetCustomersResponse
    {
        public ICollection<Customer> Customers { get; set; }
    }
}