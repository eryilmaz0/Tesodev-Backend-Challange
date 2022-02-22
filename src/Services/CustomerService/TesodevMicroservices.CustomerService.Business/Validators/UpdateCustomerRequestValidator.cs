using FluentValidation;
using TesodevMicroservices.CustomerService.Business.RequestObject;

namespace TesodevMicroservices.CustomerService.Business.Validators
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId Alanı Boş Olamaz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Alanı Boş Olamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Olamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email Formatı Doğru Değil.");
            RuleFor(x => x.AddressLine).NotEmpty().WithMessage("AddressLine Alanı Boş Olamaz.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City Alanı Boş Olamaz.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country Alanı Boş Olamaz.");
            RuleFor(x => x.CityCode).GreaterThan(0).WithMessage("CityCode Alanı Boş Olamaz.");
        }
    }
}