using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveRequests.Request.Query
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDTO>>
    {
    }
}
