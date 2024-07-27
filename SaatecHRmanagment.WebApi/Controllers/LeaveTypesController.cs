using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaatecHrManagment.Application.DTOs.LeaveType;
using SaatecHrManagment.Application.Features.LeaveTypes.Requests.Command;
using SaatecHrManagment.Application.Features.LeaveTypes.Requests.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaatecHRmanagment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
 
        }
        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTO>>> GetAsync()
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeListRequest());
            Console.WriteLine($"!!!!!!!!!!{leaveType.Count}");
            return Ok(leaveType);
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> GetAsync(int id)
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
            return Ok(leaveTypes);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreateLeaveTypeDTO input)
        {
            var response = await _mediator.Send(new CreateLeaveTypeRequest { CreateLeaveTypeDTO = input });
            return Ok(response);
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromBody] LeaveTypeDTO input)
        {
            await _mediator.Send(new UpdateLeaveTypeCommand { LeaveTypeDTO = input });
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });
            return NoContent();
        }
    }
}
