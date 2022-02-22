using System.Threading.Tasks;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Proxy;
using TesodevMicroservices.OrderService.Application.Proxy.Object;

namespace TesodevMicroservices.OrderService.Infrastructure.Proxy.CustomerServiceProxy
{
    public class MockCustomerServiceProxy : ICustomerServiceProxy
    {
        private readonly bool returnSuccess;

        public MockCustomerServiceProxy(bool returnSuccess)
        {
            this.returnSuccess = returnSuccess;
        }

        public Task<ServiceResponse<ValidateCustomerResponse>> ValidateCustomer(ValidateCustomerRequest request)
        {
            if(returnSuccess)
                return Task.FromResult(new ServiceResponse<ValidateCustomerResponse>(true, "Success", new(){IsValid = true, ValidationResultMessage = "Valid"}));

            return Task.FromResult(new ServiceResponse<ValidateCustomerResponse>(false, "Failed", new() { IsValid = false, ValidationResultMessage = "Not Valid" }));

        }
    }
}