using FluentValidation;
using TesodevMicroservices.OrderService.Application.Command;

namespace TesodevMicroservices.OrderService.Application.Validator.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Order).NotNull().WithMessage("Order Object Can not be Null.").SetValidator(new UpdateOrderDtoValidator());
        }
    }
}