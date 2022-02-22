using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Query;
using TesodevMicroservices.OrderService.Application.Repository;
using TesodevMicroservices.OrderService.Application.ResponseObject;
using TesodevMicroservices.OrderService.Application.ViewModel;

namespace TesodevMicroservices.OrderService.Application.Handler
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, ServiceResponse<GetOrdersQueryResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;


        public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetOrdersQueryResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = _orderRepository.GetAll();
            var mappedOrders = _mapper.Map<List<ListOrdersViewModel>>(orders);
            return new(true, "Orders Fetched Successfully.", new(){Orders = mappedOrders});
        }
    }
}