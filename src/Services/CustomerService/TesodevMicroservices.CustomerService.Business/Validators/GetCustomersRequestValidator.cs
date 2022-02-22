using FluentValidation;
using TesodevMicroservices.CustomerService.Business.RequestObject;

namespace TesodevMicroservices.CustomerService.Business.Validators
{
    public class GetCustomersRequestValidator : AbstractValidator<GetCustomersRequest>
    {
        public GetCustomersRequestValidator()
        {
            
        }
    }
}