using FluentValidation;
using TesodevMicroservices.OrderService.Application.Command;

namespace TesodevMicroservices.OrderService.Application.Validator.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandValidator : AbstractValidator<ChangeOrderStatusCommand>
    {
        public ChangeOrderStatusCommandValidator()
        {
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status Field Can not be Null or Empty.");
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId Field can not be Null or Empty.");
        }
    }
}