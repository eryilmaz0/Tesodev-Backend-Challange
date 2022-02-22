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
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, ServiceResponse<GetOrderByIdQueryResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<GetOrderByIdQueryResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            //Checking is order exist
            var order = _orderRepository.Get(x => x.Id == request.OrderId);

            if (order is null)
                return new(false, "Order Not Found.");

            var mappedOrder = _mapper.Map<OrderViewModel>(order);

            return new(true, "Order Fetched Successfully.", new() { Order = mappedOrder });
        }
    }
}