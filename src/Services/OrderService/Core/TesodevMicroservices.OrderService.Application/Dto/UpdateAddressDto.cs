﻿namespace TesodevMicroservices.OrderService.Application.Dto
{
    public class UpdateAddressDto
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
    }
}