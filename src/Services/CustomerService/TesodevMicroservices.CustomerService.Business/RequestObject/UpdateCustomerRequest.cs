﻿using System;

namespace TesodevMicroservices.CustomerService.Business.RequestObject
{
    public class UpdateCustomerRequest
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
    }
}