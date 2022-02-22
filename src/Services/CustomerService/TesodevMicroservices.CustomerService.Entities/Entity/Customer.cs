using System;
using TesodevMicroservices.Core.Entity.Base;
using TesodevMicroservices.Core.Entity.Child;

namespace TesodevMicroservices.CustomerService.Entities.Entity
{
    public class Customer : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}