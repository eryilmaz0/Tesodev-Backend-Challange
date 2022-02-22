using System;
using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.ResponseObject;

namespace TesodevMicroservices.OrderService.Application.Query
{
    public class GetOrderByIdQuery : IRequest<ServiceResponse<GetOrderByIdQueryResponse>>
    {
        public Guid OrderId { get; set; }
    }
}