using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Proxy;
using TesodevMicroservices.OrderService.Application.Query;
using TesodevMicroservices.OrderService.Application.Repository;
using TesodevMicroservices.OrderService.Application.ResponseObject;
using TesodevMicroservices.OrderService.Application.ViewModel;

namespace TesodevMicroservices.OrderService.Application.Handler
{
    public class GetOrdersByCustomerQueryHandler : IRequestHandler<GetOrdersByCustomerQuery, ServiceResponse<GetOrdersByCustomerQueryResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ICustomerServiceProxy _customerServiceProxy;

        public GetOrdersByCustomerQueryHandler(IOrderRepository orderRepository, IMapper mapper, ICustomerServiceProxy customerServiceProxy)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _customerServiceProxy = customerServiceProxy;
        }


        public async Task<ServiceResponse<GetOrdersByCustomerQueryResponse>> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            //Is Customer Valid?
            var validateCustomerResponse = await _customerServiceProxy.ValidateCustomer(new() { CustomerId = request.CustomerId });

            if (!validateCustomerResponse.IsSuccess || !validateCustomerResponse.Data.IsValid)
                return new(false, "Customer is not Valid.");


            var orders = _orderRepository.GetAll(x => x.CustomerId == request.CustomerId);
            var mappedOrders = _mapper.Map<List<ListOrdersViewModel>>(orders);
            return new(true, "Orders Fetched Successfully.", new(){Orders = mappedOrders});
        }
    }
}