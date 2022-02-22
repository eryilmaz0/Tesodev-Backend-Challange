namespace TesodevMicroservices.OrderService.Application.Proxy.Object
{
    public class ValidateCustomerResponse
    {
        public bool IsValid { get; set; }
        public string ValidationResultMessage { get; set; }
    }
}