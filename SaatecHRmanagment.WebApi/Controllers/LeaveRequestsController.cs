using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaatecHrManagment.Application.DTOs.LeaveAllocation;
using SaatecHrManagment.Application.DTOs.LeaveRequest;
using SaatecHrManagment.Application.Features.LeaveAllocations.Request.Command;
using SaatecHrManagment.Application.Features.LeaveAllocations.Request.Query;
using SaatecHrManagment.Application.Features.LeaveRequests.Request.Command;
using SaatecHrManagment.Application.Features.LeaveRequests.Request.Query;

namespace SaatecHRmanagment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;

        }
        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDTO>>> GetAsync()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDTO>> GetAsync(int id)
        {
            var leaveRequests = await _mediator.Send(new GetleaveRequestDetailRequest { Id = id });
            return Ok(leaveRequests);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreateleaveAllocationDTO input)
        {
            var response = await _mediator.Send(new CreateLeaveAllocationCommand { CreateleaveAllocationDTO = input });
            return Ok(response);
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromBody] UpdateLeaveRequestDTO input)
        {
            await _mediator.Send(new UpdateLeaveRequestCommand { UpdateLeaveRequestDTO = input});
            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return NoContent();
        }
    }
}
