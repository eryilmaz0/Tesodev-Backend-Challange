using System;
using MediatR;
using TesodevMicroservices.Core.Entity.Child;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Dto;
using TesodevMicroservices.OrderService.Application.ResponseObject;
using TesodevMicroservices.OrderService.Domain.OwnedEntity;

namespace TesodevMicroservices.OrderService.Application.Command
{
    public class CreateOrderCommand : IRequest<ServiceResponse<CreateOrderCommandResponse>>
    {
        public CreateOrderDto Order { get; set; } 
    }
}