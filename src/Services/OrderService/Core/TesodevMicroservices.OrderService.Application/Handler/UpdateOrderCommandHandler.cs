using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TesodevMicroservices.Core.Entity.Child;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Command;
using TesodevMicroservices.OrderService.Application.Dto;
using TesodevMicroservices.OrderService.Application.Proxy;
using TesodevMicroservices.OrderService.Application.Repository;
using TesodevMicroservices.OrderService.Application.ResponseObject;
using TesodevMicroservices.OrderService.Domain.Entity;
using TesodevMicroservices.OrderService.Domain.OwnedEntity;

namespace TesodevMicroservices.OrderService.Application.Handler
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ServiceResponse<UpdateOrderCommandResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerServiceProxy _customerServiceProxy;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, ICustomerServiceProxy customerServiceProxy)
        {
            _orderRepository = orderRepository;
            _customerServiceProxy = customerServiceProxy;
        }


        public async Task<ServiceResponse<UpdateOrderCommandResponse>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            //Checking is Order Exist
            var order = _orderRepository.Get(x => x.Id == request.Order.Id);

            if (order is null)
                return new(false, "Order Not Found.");

            //CustomerId Updating. Check the customer is valid
            if (order.CustomerId != request.Order.CustomerId)
            {
                var validateCustomerResponse = await _customerServiceProxy.ValidateCustomer(new() { CustomerId = request.Order.CustomerId });

                if (!validateCustomerResponse.IsSuccess || !validateCustomerResponse.Data.IsValid)
                    return new(false, "Customer is not Valid.");
            }
            
            UpdateOrder(order, request.Order);
            var result = _orderRepository.Update(order);

            if (!result)
                return new(false, "Update Order Operation Failed.");

            return new(true, "Order Updated Successfully.");

        }


        private Order UpdateOrder(Order order, UpdateOrderDto orderDto)
        {
            UpdateAddressDto addressDto = orderDto.Address;
            UpdateProductDto productDto = orderDto.Product;

            order.CustomerId = orderDto.CustomerId;
            order.Price = orderDto.Price;
            order.Quantity = orderDto.Quantity;
            order.Status = orderDto.Status;
            order.Address = new Address(){AddressLine = addressDto.AddressLine, City = addressDto.City, Country = addressDto.Country, CityCode = addressDto.CityCode};
            order.Product = new Product(){Id = productDto.Id, Name = productDto.Name, ImageUrl = productDto.ImageUrl};
            order.UpdatedAt = DateTime.Now;
            return order;
        }
    }
}