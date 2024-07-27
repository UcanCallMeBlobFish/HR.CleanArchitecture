using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveAllocation;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveAllocations.Request.Query
{
    public class GetLeaveAllocationsRequest : IRequest<List<LeaveAllocationDTO>>
    {
    }
}
