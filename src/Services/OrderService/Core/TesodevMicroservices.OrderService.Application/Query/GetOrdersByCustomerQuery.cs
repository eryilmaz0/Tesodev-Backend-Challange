using System;
using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.ResponseObject;

namespace TesodevMicroservices.OrderService.Application.Query
{
    public class GetOrdersByCustomerQuery : IRequest<ServiceResponse<GetOrdersByCustomerQueryResponse>>
    {
        public Guid CustomerId { get; set; }
    }
}