using FluentValidation;
using TesodevMicroservices.OrderService.Application.Dto;

namespace TesodevMicroservices.OrderService.Application.Validator
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId Field Can not be Null or Empty.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantityl Field Can not be Null or Empty.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price Field Can not be Null or Empty.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status Field Can not be Null or Empty.");

            //Child Validators
            RuleFor(x => x.Address).NotNull().WithMessage("Address Object Can not be Null.").SetValidator(new CreateAddressDtoValidator());
            RuleFor(x => x.Product).NotNull().WithMessage("Product Object Can not be Null.").SetValidator(new CreateProductDtoValidator());
        }
    }
}