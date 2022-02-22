using System;
using System.Collections.Generic;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.CustomerService.Business.Interface;
using TesodevMicroservices.CustomerService.Business.ResponseObject;
using Xunit;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using TesodevMicroservices.CustomerService.API.Controllers;
using TesodevMicroservices.CustomerService.Business.Implementation;
using TesodevMicroservices.CustomerService.Business.RequestObject;
using TesodevMicroservices.CustomerService.Entities.Entity;

namespace TesodevMicroservices.CustomerService.Api.Test
{
    public class CustomerControllerTest
    {
        [Fact]
        public void GetCustomers_Should_Return_Success()
        {
            var sut = new CustomersController(new MockCustomerManager(true));
            var result = sut.GetCustomers();

            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<GetCustomersResponse>>().Subject;

            actual.IsSuccess.Should().Be(true);
            actual.Message.Should().Be("Success");
            actual.Data.Should().NotBeNull();
            actual.Data.Customers.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
        }


        [Fact]
        public void GetCustomers_Should_Return_Failed()
        {
            var sut = new CustomersController(new MockCustomerManager(false));
            var result = sut.GetCustomers();

            var apiOkResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<GetCustomersResponse>>().Subject;

            actual.IsSuccess.Should().Be(false);
            actual.Message.Should().Be("Failed");
            actual.Data.Should().BeNull();
        }



        [Fact]
        public void GetCustomerById_Should_Return_Success()
        {
            var sut = new CustomersController(new MockCustomerManager());
            var result = sut.GetCustomerById(Guid.NewGuid());

            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<GetCustomerByIdResponse>>().Subject;

            actual.IsSuccess.Should().Be(true);
            actual.Message.Should().Be("Success");
            actual.Data.Should().NotBeNull();
            actual.Data.Customer.Should().NotBeNull();
        }



        [Fact]
        public void GetCustomerById_Should_Return_Fail()
        {
            var sut = new CustomersController(new MockCustomerManager());
            var result = sut.GetCustomerById(Guid.Empty);

            var apiOkResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<GetCustomerByIdResponse>>().Subject;

            actual.IsSuccess.Should().Be(false);
            actual.Message.Should().Be("Failed");
            actual.Data.Should().BeNull();
        }



        [Fact]
        public void CreateCustomer_Should_Return_Success()
        {
            var sut = new CustomersController(new MockCustomerManager(true));
            var result = sut.CreateCustomer(new()
            {
                AddressLine = "Address Line",
                City = "City",
                Country = "Country",
                CityCode = 34,
                Name = "Name",
                Email = "Email@gmail.com",

            });

            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<CreateCustomerResponse>>().Subject;

            actual.IsSuccess.Should().Be(true);
            actual.Message.Should().Be("Success");
            actual.Data.Should().NotBeNull();
            actual.Data.CustomerId.Should().NotBeEmpty();
        }


        [Fact]
        public void CreateCustomer_Should_Return_Fail()
        {
            var sut = new CustomersController(new MockCustomerManager(false));
            var result = sut.CreateCustomer(new()
            {
                AddressLine = "Address Line",
                City = "City",
                Country = "Country",
                CityCode = 34,
                Name = "Name",
                Email = "Email@gmail.com",

            });

            var apiOkResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<CreateCustomerResponse>>().Subject;

            actual.IsSuccess.Should().Be(false);
            actual.Message.Should().Be("Failed");
            actual.Data.Should().BeNull();
        }



        [Fact]
        public void UpdateCustomer_Should_Return_Success()
        {
            var sut = new CustomersController(new MockCustomerManager(true));
            var result = sut.UpdateCustomer(new()
            {
                CustomerId = Guid.NewGuid(),
                AddressLine = "Address Line",
                City = "City",
                Country = "Country",
                CityCode = 34,
                Name = "Name",
                Email = "Email@gmail.com",
            });

            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<UpdateCustomerResponse>>().Subject;

            actual.IsSuccess.Should().Be(true);
            actual.Message.Should().Be("Success");
            actual.Data.Should().NotBeNull();
        }



        [Fact]
        public void UpdateCustomer_Should_Return_Fail()
        {
            var sut = new CustomersController(new MockCustomerManager(false));
            var result = sut.UpdateCustomer(new()
            {
                CustomerId = Guid.Empty,
                AddressLine = "Address Line",
                City = "City",
                Country = "Country",
                CityCode = 34,
                Name = "Name",
                Email = "Email@gmail.com",
            });

            var apiOkResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<UpdateCustomerResponse>>().Subject;

            actual.IsSuccess.Should().Be(false);
            actual.Message.Should().Be("Failed");
            actual.Data.Should().BeNull();
        }



        [Fact]
        public void DeleteCustomer_Should_Return_Success()
        {
            var sut = new CustomersController(new MockCustomerManager());
            var result = sut.DeleteCustomer(new()
            {
                CustomerId = Guid.NewGuid()
            });

            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<DeleteCustomerResponse>>().Subject;

            actual.IsSuccess.Should().Be(true);
            actual.Message.Should().Be("Success");
            actual.Data.Should().NotBeNull();
        }



        [Fact]
        public void DeleteCustomer_Should_Return_Fail()
        {
            var sut = new CustomersController(new MockCustomerManager());
            var result = sut.DeleteCustomer(new()
            {
                CustomerId = Guid.Empty
            });

            var apiOkResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<DeleteCustomerResponse>>().Subject;

            actual.IsSuccess.Should().Be(false);
            actual.Message.Should().Be("Failed");
            actual.Data.Should().BeNull();
        }



        [Fact]
        public void ValidateCustomer_Should_Return_Success()
        {
            var sut = new CustomersController(new MockCustomerManager(true));
            var result = sut.ValidateCustomer(new()
            {
                CustomerId = Guid.Empty
            });

            var apiOkResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<ValidateCustomerResponse>>().Subject;

            actual.IsSuccess.Should().Be(true);
            actual.Message.Should().Be("Success");
            actual.Data.Should().NotBeNull();
            actual.Data.IsValid.Should().Be(true);
            actual.Data.ValidationResultMessage.Should().Be("Valid");
        }



        [Fact]
        public void ValidateCustomer_Should_Return_Fail()
        {
            var sut = new CustomersController(new MockCustomerManager(false));
            var result = sut.ValidateCustomer(new()
            {
                CustomerId = Guid.Empty
            });

            var apiOkResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
            var actual = apiOkResult.Value.Should().BeAssignableTo<ServiceResponse<ValidateCustomerResponse>>().Subject;

            actual.IsSuccess.Should().Be(false);
            actual.Message.Should().Be("Failed");
            actual.Data.Should().NotBeNull();
            actual.Data.IsValid.Should().Be(false);
            actual.Data.ValidationResultMessage.Should().Be("Not Valid");
        }



    }
}