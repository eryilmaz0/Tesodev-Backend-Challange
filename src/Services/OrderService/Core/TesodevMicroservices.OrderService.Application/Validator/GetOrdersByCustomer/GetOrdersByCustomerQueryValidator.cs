using FluentValidation;
using TesodevMicroservices.OrderService.Application.Query;

namespace TesodevMicroservices.OrderService.Application.Validator.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQueryValidator : AbstractValidator<GetOrdersByCustomerQuery>
    {
        public GetOrdersByCustomerQueryValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId Field Can not be Null or Empty.");

        }
    }
}