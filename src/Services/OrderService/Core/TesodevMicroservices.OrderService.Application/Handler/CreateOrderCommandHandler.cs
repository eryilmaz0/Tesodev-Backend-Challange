using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Command;
using TesodevMicroservices.OrderService.Application.Proxy;
using TesodevMicroservices.OrderService.Application.Repository;
using TesodevMicroservices.OrderService.Application.ResponseObject;
using TesodevMicroservices.OrderService.Domain.Entity;

namespace TesodevMicroservices.OrderService.Application.Handler
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ServiceResponse<CreateOrderCommandResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ICustomerServiceProxy _customerServiceProxy;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ICustomerServiceProxy customerServiceProxy)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _customerServiceProxy = customerServiceProxy;
        }


        public async Task<ServiceResponse<CreateOrderCommandResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            //Is Customer Valid?
            var validateCustomerResponse = await _customerServiceProxy.ValidateCustomer(new(){CustomerId = request.Order.CustomerId});

            if (!validateCustomerResponse.IsSuccess || !validateCustomerResponse.Data.IsValid)
                return new(false, "Customer is not Valid.");

            Order newOrder = _mapper.Map<Order>(request.Order);
            var result = _orderRepository.Insert(newOrder);

            return new ServiceResponse<CreateOrderCommandResponse>(true, "Order Created Successfully.", new(){OrderId = result});
        }
    }
}