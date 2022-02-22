using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Command;
using TesodevMicroservices.OrderService.Application.Repository;
using TesodevMicroservices.OrderService.Application.ResponseObject;

namespace TesodevMicroservices.OrderService.Application.Handler
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, ServiceResponse<DeleteOrderCommandResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<ServiceResponse<DeleteOrderCommandResponse>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            //Checking Order is exist
            var order = _orderRepository.Get(x => x.Id == request.OrderId);

            if (order is null)
                return new(false, "Order Not Found.");

            var result = _orderRepository.Delete(order);

            if (!result)
                return new(false, "Delete Order Operation Failed.");

            return new(true, "Order Deleted Successfully.");

        }
    }
}