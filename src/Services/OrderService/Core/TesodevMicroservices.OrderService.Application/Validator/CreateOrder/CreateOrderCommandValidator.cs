using FluentValidation;
using TesodevMicroservices.OrderService.Application.Command;

namespace TesodevMicroservices.OrderService.Application.Validator
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Order).NotNull().WithMessage("Order Object Can not be Null.").SetValidator(new CreateOrderDtoValidator());
        }
    }
}