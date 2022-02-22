using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesodevMicroservices.CustomerService.Business.Interface;
using TesodevMicroservices.CustomerService.Business.RequestObject;

namespace TesodevMicroservices.CustomerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var result = _customerService.CreateCustomer(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }



        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] UpdateCustomerRequest request)
        {
            var result = _customerService.UpdateCustomer(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }



        [HttpDelete]
        public IActionResult DeleteCustomer([FromBody] DeleteCustomerRequest request)
        {
            var result = _customerService.DeleteCustomer(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpGet]
        public IActionResult GetCustomers()
        {
            var result = _customerService.GetCustomers(new());

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpGet]
        [Route("{customerId}")]
        public IActionResult GetCustomerById([FromRoute] Guid customerId)
        {
            var result = _customerService.GetCustomerById(new(){CustomerId = customerId});

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPost]
        [Route("Validate")]
        public IActionResult ValidateCustomer([FromBody] ValidateCustomerRequest request)
        {
            var result = _customerService.ValidateCustomer(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
