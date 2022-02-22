using System;
using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.ResponseObject;

namespace TesodevMicroservices.OrderService.Application.Command
{
    public class DeleteOrderCommand : IRequest<ServiceResponse<DeleteOrderCommandResponse>>
    {
        public Guid OrderId { get; set; }
    }
}