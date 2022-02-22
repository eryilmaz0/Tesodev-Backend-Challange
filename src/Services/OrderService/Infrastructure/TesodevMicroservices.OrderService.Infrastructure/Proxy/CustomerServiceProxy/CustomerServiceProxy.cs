using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Proxy;
using TesodevMicroservices.OrderService.Application.Proxy.Object;


namespace TesodevMicroservices.OrderService.Infrastructure.Proxy.CustomerServiceProxy
{
    public class CustomerServiceProxy : ICustomerServiceProxy
    {
        private readonly HttpClient _httpClient;

        public CustomerServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ServiceResponse<ValidateCustomerResponse>> ValidateCustomer(ValidateCustomerRequest request)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync<ValidateCustomerRequest>("Validate", request);
            var response = await httpResponse.Content.ReadFromJsonAsync<ServiceResponse<ValidateCustomerResponse>>();

            if (httpResponse is null || response is null || httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                return new(false, "Proxy Error");

            if (httpResponse.StatusCode != HttpStatusCode.OK || !response.Data.IsValid)
                return new(false, response.Data.ValidationResultMessage, response.Data);

            return new(true, response.Data.ValidationResultMessage, response.Data);
        }

    }
}