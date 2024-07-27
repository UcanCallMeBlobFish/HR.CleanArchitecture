using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaatecHrManagment.Application.DTOs.LeaveAllocation;
using SaatecHrManagment.Application.DTOs.LeaveType;
using SaatecHrManagment.Application.Features.LeaveAllocations.Request.Command;
using SaatecHrManagment.Application.Features.LeaveAllocations.Request.Query;
using SaatecHrManagment.Application.Features.LeaveTypes.Requests.Command;
using SaatecHrManagment.Application.Features.LeaveTypes.Requests.Query;

namespace SaatecHRmanagment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;

        }
        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDTO>>> GetAsync()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationsRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDTO>> GetAsync(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreateleaveAllocationDTO input)
        {
            var response = await _mediator.Send(new CreateLeaveAllocationCommand { CreateleaveAllocationDTO = input });
            return Ok(response);
        }

        // PUT api/<LeaveAllocationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromBody] UpdateLeaveAllocationDTO input)
        {
            await _mediator.Send(new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDTO = input });
            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
            return NoContent();
        }
    }
}
