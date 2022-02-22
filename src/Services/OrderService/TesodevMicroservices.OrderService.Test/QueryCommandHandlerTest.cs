using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TesodevMicroservices.Core.ServiceResponse;
using TesodevMicroservices.OrderService.Application.Handler;
using TesodevMicroservices.OrderService.Application.ResponseObject;
using TesodevMicroservices.OrderService.Infrastructure.Proxy.CustomerServiceProxy;
using TesodevMicroservices.OrderService.Infrastructure.Repository.EntityFramework;
using TesodevMicroservices.OrderService.Test.Mock;
using Xunit;

namespace TesodevMicroservices.OrderService.Test
{
    public class QueryCommandHandlerTest
    {
        [Fact]
        public async Task ChangeOrderStatusCommandHandler_Should_Return_Success()
        {
            var handler = new ChangeOrderStatusCommandHandler(new MockOrderRepository(true));
            var result = await handler.Handle(new() { OrderId = Guid.NewGuid() }, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<ChangeOrderStatusCommandResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(true);
            handlerResult.Message.Should().Be("Order Status Updated Successfully.");
            handlerResult.Data.Should().NotBeNull();
        }


        [Fact]
        public async Task CreateOrderCommandHandler_Should_Return_Success()
        {
            var handler = new CreateOrderCommandHandler(new MockOrderRepository(true), new MockMapper(), new MockCustomerServiceProxy(true));
            var result = await handler.Handle(new() { Order = new()}, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<CreateOrderCommandResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(true);
            handlerResult.Message.Should().Be("Order Created Successfully.");
            handlerResult.Data.Should().NotBeNull();
            handlerResult.Data.OrderId.Should().NotBeEmpty();
        }


        [Fact]
        public async Task CreateOrderCommandHandler_Should_Return_Fail()
        {
            var handler = new CreateOrderCommandHandler(new MockOrderRepository(true), new MockMapper(), new MockCustomerServiceProxy(false));
            var result = await handler.Handle(new() { Order = new() }, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<CreateOrderCommandResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(false);
            handlerResult.Message.Should().Be("Customer is not Valid.");
            handlerResult.Data.Should().BeNull();
        }


        [Fact]
        public async Task DeleteOrderCommandHandler_Should_Return_Success()
        {
            var handler = new DeleteOrderCommandHandler(new MockOrderRepository(true));
            var result = await handler.Handle(new(){OrderId = Guid.NewGuid()}, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<DeleteOrderCommandResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(true);
            handlerResult.Message.Should().Be("Order Deleted Successfully.");
            handlerResult.Data.Should().BeNull();
        }


        [Fact]
        public async Task DeleteOrderCommandHandler_Should_Return_Fail()
        {
            var handler = new DeleteOrderCommandHandler(new MockOrderRepository(false));
            var result = await handler.Handle(new() { OrderId = Guid.NewGuid() }, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<DeleteOrderCommandResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(false);
            handlerResult.Message.Should().Be("Order Not Found.");
            handlerResult.Data.Should().BeNull();
        }


        [Fact]
        public async Task GetOrderByIdQueryHandler_Should_Return_Success()
        {
            var handler = new GetOrderByIdQueryHandler(new MockOrderRepository(true), new MockMapper());
            var result = await handler.Handle(new() { OrderId = Guid.NewGuid() }, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<GetOrderByIdQueryResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(true);
            handlerResult.Message.Should().Be("Order Fetched Successfully.");
            handlerResult.Data.Should().NotBeNull();
            handlerResult.Data.Order.Should().NotBeNull();
        }


        [Fact]
        public async Task GetOrderByIdQueryHandler_Should_Return_Fail()
        {
            var handler = new GetOrderByIdQueryHandler(new MockOrderRepository(false), new MockMapper());
            var result = await handler.Handle(new() { OrderId = Guid.NewGuid() }, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<GetOrderByIdQueryResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(false);
            handlerResult.Message.Should().Be("Order Not Found.");
            handlerResult.Data.Should().BeNull();
        }


        [Fact]
        public async Task GetOrdersByCustomerQueryHandler_Should_Return_Success()
        {
            var handler = new GetOrdersByCustomerQueryHandler(new MockOrderRepository(true), new MockMapper(), new MockCustomerServiceProxy(true));
            var result = await handler.Handle(new() { CustomerId = Guid.NewGuid()}, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<GetOrdersByCustomerQueryResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(true);
            handlerResult.Message.Should().Be("Orders Fetched Successfully.");
            handlerResult.Data.Should().NotBeNull();
            handlerResult.Data.Orders.Should().NotBeEmpty();
        }


        [Fact]
        public async Task GetOrdersByCustomerQueryHandler_Should_Return_Fail()
        {
            var handler = new GetOrdersByCustomerQueryHandler(new MockOrderRepository(false), new MockMapper(), new MockCustomerServiceProxy(false));
            var result = await handler.Handle(new() { CustomerId = Guid.NewGuid() }, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<GetOrdersByCustomerQueryResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(false);
            handlerResult.Message.Should().Be("Customer is not Valid.");
            handlerResult.Data.Should().BeNull();
        }


        [Fact]
        public async Task GetOrdersQueryHandler_Should_Return_Success()
        {
            var handler = new GetOrdersQueryHandler(new MockOrderRepository(true), new MockMapper());
            var result = await handler.Handle(new(), new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<GetOrdersQueryResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(true);
            handlerResult.Message.Should().Be("Orders Fetched Successfully.");
            handlerResult.Data.Should().NotBeNull();
            handlerResult.Data.Orders.Should().NotBeEmpty();
        }


        [Fact]
        public async Task UpdateOrderCommandHandler_Should_Return_Success()
        {
            var handler = new UpdateOrderCommandHandler(new MockOrderRepository(true), new MockCustomerServiceProxy(true));
            var result = await handler.Handle(new(){Order = new()
            {
                Id = Guid.NewGuid(), 
                CustomerId = Guid.NewGuid(),
                Address = new(){AddressLine = "Address", City = "City", Country = "Country", CityCode = 13},
                Product = new(){Id = Guid.NewGuid(), Name = "Product", ImageUrl = "ProductImage.jpg"},
                Price = 100,
                Quantity = 1
            }}, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<UpdateOrderCommandResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(true);
            handlerResult.Message.Should().Be("Order Updated Successfully.");
            handlerResult.Data.Should().BeNull();
        }


        [Fact]
        public async Task UpdateOrderCommandHandler_Should_Return_Fail()
        {
            var handler = new UpdateOrderCommandHandler(new MockOrderRepository(false), new MockCustomerServiceProxy(false));
            var result = await handler.Handle(new()
            {
                Order = new()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.NewGuid(),
                    Address = new() { AddressLine = "Address", City = "City", Country = "Country", CityCode = 13 },
                    Product = new() { Id = Guid.NewGuid(), Name = "Product", ImageUrl = "ProductImage.jpg" },
                    Price = 100,
                    Quantity = 1
                }
            }, new());

            var handlerResult = result.Should().BeOfType<ServiceResponse<UpdateOrderCommandResponse>>().Subject;

            handlerResult.IsSuccess.Should().Be(false);
            handlerResult.Message.Should().Be("Order Not Found.");
            handlerResult.Data.Should().BeNull();
        }
    }

}