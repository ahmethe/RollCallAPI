using Entities.Models;
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

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _service.CustomerService.GetAllCustomers(false);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _service.CustomerService.GetCustomerById(id, false);

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            _service.CustomerService.AddCustomer(customer);
            
            return StatusCode(201, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            _service.CustomerService.UpdateCustomer(id, customer, true);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _service.CustomerService.DeleteCustomer(id, false);

            return NoContent();
        }
    }
}
