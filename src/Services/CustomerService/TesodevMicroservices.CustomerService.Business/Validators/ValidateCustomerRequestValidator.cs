using FluentValidation;
using TesodevMicroservices.CustomerService.Business.RequestObject;

namespace TesodevMicroservices.CustomerService.Business.Validators
{
    public class ValidateCustomerRequestValidator : AbstractValidator<ValidateCustomerRequest>
    {
        public ValidateCustomerRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId Alanı Boş Olamaz.");
        }
    }
}