using TesodevMicroservices.OrderService.Application.ViewModel;

namespace TesodevMicroservices.OrderService.Application.ResponseObject
{
    public class GetOrderByIdQueryResponse
    {
        public OrderViewModel Order { get; set; }
    }
}