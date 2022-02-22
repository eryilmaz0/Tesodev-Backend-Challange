using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Dto;
using TesodevMicroservices.OrderService.Application.ResponseObject;

namespace TesodevMicroservices.OrderService.Application.Command
{
    public class UpdateOrderCommand : IRequest<ServiceResponse<UpdateOrderCommandResponse>>
    {
        public UpdateOrderDto Order { get; set; }
    }
}