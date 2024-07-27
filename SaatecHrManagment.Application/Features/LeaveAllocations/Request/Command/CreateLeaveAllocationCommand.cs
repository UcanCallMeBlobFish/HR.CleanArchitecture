using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveAllocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveAllocations.Request.Command
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public CreateleaveAllocationDTO CreateleaveAllocationDTO { get; set; }
    }
}
