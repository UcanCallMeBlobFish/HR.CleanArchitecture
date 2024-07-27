using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveAllocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveAllocations.Request.Command
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
