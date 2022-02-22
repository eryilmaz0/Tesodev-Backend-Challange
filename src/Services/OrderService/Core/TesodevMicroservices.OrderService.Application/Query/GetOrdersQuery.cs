using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.ResponseObject;

namespace TesodevMicroservices.OrderService.Application.Query
{
    public class GetOrdersQuery : IRequest<ServiceResponse<GetOrdersQueryResponse>>
    {
        
    }
}