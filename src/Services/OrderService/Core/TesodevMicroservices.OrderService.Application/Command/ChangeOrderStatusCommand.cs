using System;
using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.ResponseObject;

namespace TesodevMicroservices.OrderService.Application.Command
{
    public class ChangeOrderStatusCommand : IRequest<ServiceResponse<ChangeOrderStatusCommandResponse>>
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
    }
}