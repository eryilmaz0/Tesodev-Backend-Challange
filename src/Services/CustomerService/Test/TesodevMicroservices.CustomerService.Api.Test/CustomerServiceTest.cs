using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.CustomerService.API.Controllers;
using TesodevMicroservices.CustomerService.Business.Implementation;
using TesodevMicroservices.CustomerService.Business.Interface;
using TesodevMicroservices.CustomerService.Business.ResponseObject;
using TesodevMicroservices.CustomerService.DataAccess.Implementation.EntityFramework;
using Xunit;

namespace TesodevMicroservices.CustomerService.Api.Test
{
    public class CustomerServiceTest
    {
        [Fact]
        public void GetCustomers_Should_Return_Success()
        {
            ICustomerService customerService = new CustomerManager(new MockCustomerRepository(true));
            var result = customerService.GetCustomers(new());

            var serviceResult = result.Should().BeOfType<ServiceResponse<GetCustomersResponse>>().Subject;

            serviceResult.IsSuccess.Should().Be(true);
            serviceResult.Message.Should().Be("Customers Listed Successfully.");
            serviceResult.Data.Should().NotBeNull();
            serviceResult.Data.Customers.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
        }


        [Fact]
        public void GetCustomerById_Should_Return_Success()
        {
            ICustomerService customerService = new CustomerManager(new MockCustomerRepository(true));
            var result = customerService.GetCustomerById(new(){CustomerId = Guid.NewGuid()});

            var serviceResult = result.Should().BeOfType<ServiceResponse<GetCustomerByIdResponse>>().Subject;

            serviceResult.IsSuccess.Should().Be(true);
            serviceResult.Message.Should().Be("Customer Fetched Successfully.");
            serviceResult.Data.Should().NotBeNull();
            serviceResult.Data.Customer.Should().NotBeNull();
        }


        [Fact]
        public void GetCustomerById_Should_Return_Fail()
        {
            ICustomerService customerService = new CustomerManager(new MockCustomerRepository(false));
            var result = customerService.GetCustomerById(new() { CustomerId = Guid.NewGuid() });

            var serviceResult = result.Should().BeOfType<ServiceResponse<GetCustomerByIdResponse>>().Subject;

            serviceResult.IsSuccess.Should().Be(false);
            serviceResult.Message.Should().Be("Customer Not Found.");
            serviceResult.Data.Should().BeNull();
        }


        [Fact]
        public void CreateCustomer_Should_Return_Success()
        {
            ICustomerService customerService = new CustomerManager(new MockCustomerRepository(false));
            var result = customerService.CreateCustomer(new()
            {
                Name = "Customer",
                Email = "Customer@hotmail.com",
                AddressLine = "Addres",
                City = "City",
                Country = "Country",
                CityCode = 34
            });

            var serviceResult = result.Should().BeOfType<ServiceResponse<CreateCustomerResponse>>().Subject;

            serviceResult.IsSuccess.Should().Be(true);
            serviceResult.Message.Should().Be("Customer Added Successfully.");
            serviceResult.Data.Should().NotBeNull();
            serviceResult.Data.CustomerId.Should().NotBeEmpty();
        }



        [Fact]
        public void DeleteCustomer_Should_Return_Success()
        {
            ICustomerService customerService = new CustomerManager(new MockCustomerRepository(true));
            var result = customerService.DeleteCustomer(new()
            {
                CustomerId = Guid.NewGuid()
            });

            var serviceResult = result.Should().BeOfType<ServiceResponse<DeleteCustomerResponse>>().Subject;

            serviceResult.IsSuccess.Should().Be(true);
            serviceResult.Message.Should().Be("Customer Deleted Successfully.");
            serviceResult.Data.Should().BeNull();
        }


        [Fact]
        public void DeleteCustomer_Should_Return_Fail()
        {
            ICustomerService customerService = new CustomerManager(new MockCustomerRepository(false));
            var result = customerService.DeleteCustomer(new()
            {
                CustomerId = Guid.NewGuid()
            });

            var serviceResult = result.Should().BeOfType<ServiceResponse<DeleteCustomerResponse>>().Subject;

            serviceResult.IsSuccess.Should().Be(false);
            serviceResult.Message.Should().Be("Customer not found.");
            serviceResult.Data.Should().BeNull();
        }



        [Fact]
        public void UpdateCustomer_Should_Return_Success()
        {
            ICustomerService customerService = new CustomerManager(new MockCustomerRepository(true));
            var result = customerService.UpdateCustomer(new()
            {
                CustomerId = Guid.NewGuid(),
                Name = "Customer",
                Email = "Customer@hotmail.com",
                AddressLine = "Address",
                City = "City",
                Country = "Country",
                CityCode = 34
            });

            var serviceResult = result.Should().BeOfType<ServiceResponse<UpdateCustomerResponse>>().Subject;

            serviceResult.IsSuccess.Should().Be(true);
            serviceResult.Message.Should().Be("Customer Updated Successfully.");
            serviceResult.Data.Should().BeNull();
        }



        [Fact]
        public void UpdateCustomer_Should_Return_Fail()
        {
            ICustomerService customerService = new CustomerManager(new MockCustomerRepository(false));
            var result = customerService.UpdateCustomer(new()
            {
                CustomerId = Guid.NewGuid(),
                Name = "Customer",
                Email = "Customer@hotmail.com",
                AddressLine = "Address",
                City = "City",
                Country = "Country",
                CityCode = 34
            });

            var serviceResult = result.Should().BeOfType<ServiceResponse<UpdateCustomerResponse>>().Subject;

            serviceResult.IsSuccess.Should().Be(false);
            serviceResult.Message.Should().Be("Customer not found.");
            serviceResult.Data.Should().BeNull();
        }


        [Fact]
        public void ValidateCustomer_Should_Return_Success()
        {
            ICustomerService customerService = new CustomerManager(new MockCustomerRepository(true));
            var result = customerService.ValidateCustomer(new()
            {
                CustomerId = Guid.NewGuid()
            });

            var serviceResult = result.Should().BeOfType<ServiceResponse<ValidateCustomerResponse>>().Subject;

            serviceResult.IsSuccess.Should().Be(true);
            serviceResult.Message.Should().Be("Customer Validated Successfully.");
            serviceResult.Data.Should().NotBeNull();
            serviceResult.Data.IsValid.Should().Be(true);
            serviceResult.Data.ValidationResultMessage.Should().Be("Customer Validated Successfully.");
        }



        [Fact]
        public void ValidateCustomer_Should_Return_Fail()
        {
            ICustomerService customerService = new CustomerManager(new MockCustomerRepository(false));
            var result = customerService.ValidateCustomer(new()
            {
                CustomerId = Guid.NewGuid()
            });

            var serviceResult = result.Should().BeOfType<ServiceResponse<ValidateCustomerResponse>>().Subject;

            serviceResult.IsSuccess.Should().Be(false);
            serviceResult.Message.Should().Be("Customer not found.");
            serviceResult.Data.Should().NotBeNull();
            serviceResult.Data.IsValid.Should().Be(false);
            serviceResult.Data.ValidationResultMessage.Should().Be("Customer Not Found.");
        }
    }
}