using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/RollCalls")]
    public class RollCallsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public RollCallsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllRollCalls()
        {
            var RollCalls = _service.RollCallService.GetAllRollCalls(false);
            return Ok(RollCalls);
        }

        [HttpGet("{id}")]
        public IActionResult GetRollCallById(int id)
        {
            var RollCall = _service.RollCallService.GetRollCallById(id, false);

            return Ok(RollCall);
        }

        [HttpPost]
        public IActionResult AddRollCall([FromBody] RollCall RollCall)
        {
            if (RollCall == null)
                return BadRequest();

            _service.RollCallService.AddRollCall(RollCall);
            
            return StatusCode(201, RollCall);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRollCall(int id, [FromBody] RollCall RollCall)
        {
            if (RollCall == null)
                return BadRequest();

            _service.RollCallService.UpdateRollCall(id, RollCall, true);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRollCall(int id)
        {
            _service.RollCallService.DeleteRollCall(id, false);

            return NoContent();
        }
    }
}
