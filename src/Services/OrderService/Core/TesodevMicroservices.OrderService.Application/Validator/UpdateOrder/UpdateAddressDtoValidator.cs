using FluentValidation;
using TesodevMicroservices.OrderService.Application.Dto;

namespace TesodevMicroservices.OrderService.Application.Validator.UpdateOrder
{
    public class UpdateAddressDtoValidator : AbstractValidator<UpdateAddressDto>
    {
        public UpdateAddressDtoValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("Address City Field Can not be Null or Empty.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Address Country Field Can not be Null or Empty.");
            RuleFor(x => x.CityCode).NotEmpty().WithMessage("Address CityCode Field Can not be Null or Empty.");
        }
    }
}