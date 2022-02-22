using FluentValidation;
using TesodevMicroservices.CustomerService.Business.RequestObject;

namespace TesodevMicroservices.CustomerService.Business.Validators
{
    public class DeleteCustomerRequestValidator : AbstractValidator<DeleteCustomerRequest>
    {
        public DeleteCustomerRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId Alanı Boş Olamaz.");
        }
    }
}