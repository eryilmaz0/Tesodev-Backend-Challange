using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesodevMicroservices.OrderService.Application.Command;
using TesodevMicroservices.OrderService.Application.Query;

namespace TesodevMicroservices.OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromBody] DeleteOrderCommand request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }



        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _mediator.Send(new GetOrdersQuery());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }



        [HttpGet]
        [Route("ByCustomer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomer(Guid customerId)
        {
            var result = await _mediator.Send(new GetOrdersByCustomerQuery() { CustomerId = customerId });

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }



        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery() { OrderId = orderId });

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }



        [HttpPut]
        [Route("Status")]
        public async Task<IActionResult> ChangeOrderStatus([FromBody] ChangeOrderStatusCommand request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        
    }
}
