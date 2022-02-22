namespace TesodevMicroservices.CustomerService.Business.ResponseObject
{
    public class ValidateCustomerResponse
    {
        public bool IsValid { get; set; }
        public string ValidationResultMessage { get; set; }
    }
}