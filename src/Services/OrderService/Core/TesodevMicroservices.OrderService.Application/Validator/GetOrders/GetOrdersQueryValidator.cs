using FluentValidation;
using TesodevMicroservices.OrderService.Application.Query;

namespace TesodevMicroservices.OrderService.Application.Validator.GetOrders
{
    public class GetOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
    {
        public GetOrdersQueryValidator()
        {
            //
        }
    }
}