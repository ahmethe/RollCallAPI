using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CustomersController(IServiceManager service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _service.CustomerService.GetAllCustomers(false);
            return Ok(customers);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public IActionResult GetCustomerById([FromRoute] int id)
        {
            var customer = _service.CustomerService.GetCustomerById(id, false);

            return Ok(customer);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
                return BadRequest();

            _service.CustomerService.AddCustomer(customerDto);
            
            return StatusCode(201, customerDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public IActionResult UpdateCustomer([FromRoute] int id, [FromBody] CustomerDtoForUpdate customerDto)
        {
            if (customerDto == null)
                return BadRequest();

            _service.CustomerService.UpdateCustomer(id, customerDto, true);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            _service.CustomerService.DeleteCustomer(id, false);

            return NoContent();
        }
    }
}
