using System;
using TesodevMicroservices.Core.Entity.Child;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.CustomerService.Business.Interface;
using TesodevMicroservices.CustomerService.Business.RequestObject;
using TesodevMicroservices.CustomerService.Business.ResponseObject;
using TesodevMicroservices.CustomerService.DataAccess.Interface;
using TesodevMicroservices.CustomerService.Entities.Entity;

namespace TesodevMicroservices.CustomerService.Business.Implementation
{
    public class CustomerManager : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public ServiceResponse<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request)
        {
            //Checking is customer already exist
            var customer = _customerRepository.Get(x => x.Email == request.Email);

            if (customer is not null)
                return new(false, "Customer already exist.");

            Address newAddress = new(){AddressLine = request.AddressLine, City = request.City, Country = request.Country, CityCode = request.CityCode};
            Customer newCustomer = new() { Name = request.Name, Email = request.Email, Address = newAddress };

            var result = _customerRepository.Insert(newCustomer);
            return new(true, "Customer Added Successfully.", new(){CustomerId = result});

        }



        public ServiceResponse<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest request)
        {
            //Checking is customer exist
            var customer = _customerRepository.Get(x => x.Id == request.CustomerId);

            if (customer is null)
                return new(false, "Customer not found.");

            Address newAddress = new() { AddressLine = request.AddressLine, City = request.City, Country = request.Country, CityCode = request.CityCode };
            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.Address = newAddress;
            customer.UpdatedAt = DateTime.Now;

            var result = _customerRepository.Update(customer);

            if(!result)
                return new(false, "Update Customer Operation is Failed.");

            return new(true, "Customer Updated Successfully.");
        }




        public ServiceResponse<DeleteCustomerResponse> DeleteCustomer(DeleteCustomerRequest request)
        {
            //Checking is customer exist
            var customer = _customerRepository.Get(x => x.Id == request.CustomerId);

            if (customer is null)
                return new(false, "Customer not found.");

            var result = _customerRepository.Delete(customer);

            if (!result)
                return new(false, "Delete Customer Operation is Failed.");

            return new(true, "Customer Deleted Successfully.");
        }




        public ServiceResponse<GetCustomersResponse> GetCustomers(GetCustomersRequest request)
        {
            return new()
            {
                IsSuccess = true,
                Message = "Customers Listed Successfully.",
                Data = new(){ Customers = _customerRepository.GetAll() }
            };
        }




        public ServiceResponse<GetCustomerByIdResponse> GetCustomerById(GetCustomerByIdRequest request)
        {
            var customer = _customerRepository.Get(x => x.Id == request.CustomerId);

            if (customer is null)
                return new(false, "Customer Not Found.");

            return new(true, "Customer Fetched Successfully.", new() { Customer = customer });
        }



        public ServiceResponse<ValidateCustomerResponse> ValidateCustomer(ValidateCustomerRequest request)
        {
            //Checking is customer exist
            var customer = _customerRepository.Get(x => x.Id == request.CustomerId);

            if (customer is null)
                return new(false, "Customer not found.", new(){IsValid = false, ValidationResultMessage = "Customer Not Found."});

            return new(true, "Customer Validated Successfully.", new(){IsValid = true, ValidationResultMessage = "Customer Validated Successfully." });

        }

    }
}