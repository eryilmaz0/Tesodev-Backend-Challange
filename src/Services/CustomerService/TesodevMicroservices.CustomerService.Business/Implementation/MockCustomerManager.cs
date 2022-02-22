using System;
using System.Collections.Generic;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.CustomerService.Business.Interface;
using TesodevMicroservices.CustomerService.Business.RequestObject;
using TesodevMicroservices.CustomerService.Business.ResponseObject;
using TesodevMicroservices.CustomerService.Entities.Entity;

namespace TesodevMicroservices.CustomerService.Business.Implementation
{
    public class MockCustomerManager : ICustomerService
    {
        private readonly bool returnSuccess;

        public MockCustomerManager(bool returnSuccess)
        {
            this.returnSuccess = returnSuccess;
        }

        public MockCustomerManager()
        {
            
        }

        public ServiceResponse<GetCustomersResponse> GetCustomers(GetCustomersRequest request)
        {
            if(returnSuccess)
                return new ServiceResponse<GetCustomersResponse>(true, "Success", new(){Customers = new List<Customer>(){new(), new(), new()}});

            return new ServiceResponse<GetCustomersResponse>(false, "Failed");
        }


        public ServiceResponse<GetCustomerByIdResponse> GetCustomerById(GetCustomerByIdRequest request)
        {
            if(request.CustomerId != Guid.Empty)
                return new ServiceResponse<GetCustomerByIdResponse>(true, "Success", new(){Customer = new()});

            return new ServiceResponse<GetCustomerByIdResponse>(false, "Failed");
        }


        public ServiceResponse<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request)
        {
            if(returnSuccess)
                return new ServiceResponse<CreateCustomerResponse>(true,"Success", new(){CustomerId = Guid.NewGuid()});

            return new ServiceResponse<CreateCustomerResponse>(false, "Failed");
        }

        public ServiceResponse<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest request)
        {
            if (returnSuccess)
                return new ServiceResponse<UpdateCustomerResponse>(true, "Success", new(){});

            return new ServiceResponse<UpdateCustomerResponse>(false, "Failed");
        }

        public ServiceResponse<DeleteCustomerResponse> DeleteCustomer(DeleteCustomerRequest request)
        {
            if (request.CustomerId != Guid.Empty)
                return new ServiceResponse<DeleteCustomerResponse>(true, "Success", new() { });

            return new ServiceResponse<DeleteCustomerResponse>(false, "Failed");
        }


        

        public ServiceResponse<ValidateCustomerResponse> ValidateCustomer(ValidateCustomerRequest request)
        {
            if (returnSuccess)
                return new ServiceResponse<ValidateCustomerResponse>(true, "Success", new() {IsValid = true, ValidationResultMessage = "Valid"});

            return new ServiceResponse<ValidateCustomerResponse>(false, "Failed", new(){IsValid = false, ValidationResultMessage = "Not Valid"});
        }
    }
}