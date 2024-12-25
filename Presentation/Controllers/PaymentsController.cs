using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IServiceManager _services;

        public PaymentsController(IServiceManager services)
        {
            _services = services;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllPayments()
        {
            var payments = _services.PaymentService.GetAllPayments(false);
            return Ok(payments);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public IActionResult GetPaymentById([FromRoute] int id)
        {
            var payment = _services.PaymentService.GetPaymentById(id, false);
            return Ok(payment);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddPayment([FromBody] PaymentDtoForManipulation paymentDto)
        {
            if (paymentDto == null)
                return BadRequest();

            var entity = _services.PaymentService.AddPayment(paymentDto);

            return StatusCode(201, entity);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public IActionResult UpdatePayment([FromRoute] int id, [FromBody] PaymentDtoForManipulation paymentDto)
        {
            if (paymentDto == null)
                return BadRequest();

            _services.PaymentService.UpdatePayment(id, paymentDto, true);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult DeletPayment([FromRoute] int id)
        {
            _services.PaymentService.DeletePayment(id, false);

            return NoContent();
        }

        [Authorize]
        [HttpGet("customers")]
        public IActionResult GetAllPaymentsWithCustomers()
        {
            var payments = _services.PaymentService.GetAllPaymentsWithCustomers(false);
            return Ok(payments);
        }
    }
}
