using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Command;
using TesodevMicroservices.OrderService.Application.Repository;
using TesodevMicroservices.OrderService.Application.ResponseObject;

namespace TesodevMicroservices.OrderService.Application.Handler
{
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommand, ServiceResponse<ChangeOrderStatusCommandResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ServiceResponse<ChangeOrderStatusCommandResponse>> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            //Checking is order exist
            var order = _orderRepository.Get(x => x.Id == request.OrderId);

            if (order is null)
                return new(false, "Order Not Found.");

            order.Status = request.Status;
            order.UpdatedAt = DateTime.Now;
            var result = _orderRepository.Update(order);

            if (!result)
                return new(false, "Update Order Status Operation Failed.");

            return new(true, "Order Status Updated Successfully.", new());
        }
    }
}