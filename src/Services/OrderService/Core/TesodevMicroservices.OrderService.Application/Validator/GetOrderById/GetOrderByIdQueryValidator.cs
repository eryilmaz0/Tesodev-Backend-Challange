using FluentValidation;
using TesodevMicroservices.OrderService.Application.Query;

namespace TesodevMicroservices.OrderService.Application.Validator.GetOrderById
{
    public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetOrderByIdQueryValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId Field Can not be Null or Empty.");
        }
    }
}