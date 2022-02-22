using FluentValidation;
using TesodevMicroservices.OrderService.Application.Command;

namespace TesodevMicroservices.OrderService.Application.Validator.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId Field Can not be Null or Empty.");
        }
    }
}