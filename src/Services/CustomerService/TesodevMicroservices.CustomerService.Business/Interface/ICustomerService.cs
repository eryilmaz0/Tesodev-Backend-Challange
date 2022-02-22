using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.CustomerService.Business.RequestObject;
using TesodevMicroservices.CustomerService.Business.ResponseObject;

namespace TesodevMicroservices.CustomerService.Business.Interface
{
    public interface ICustomerService
    {
        ServiceResponse<CreateCustomerResponse> CreateCustomer(CreateCustomerRequest request);
        ServiceResponse<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest request);
        ServiceResponse<DeleteCustomerResponse> DeleteCustomer(DeleteCustomerRequest request);
        ServiceResponse<GetCustomersResponse> GetCustomers(GetCustomersRequest request);
        ServiceResponse<GetCustomerByIdResponse> GetCustomerById(GetCustomerByIdRequest request);
        ServiceResponse<ValidateCustomerResponse> ValidateCustomer(ValidateCustomerRequest request);

    }
}