using System.Threading.Tasks;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Proxy.Object;

namespace TesodevMicroservices.OrderService.Application.Proxy
{
    public interface ICustomerServiceProxy
    {
        Task<ServiceResponse<ValidateCustomerResponse>> ValidateCustomer(ValidateCustomerRequest request);
    }
}