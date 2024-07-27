using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveTypes.Requests.Query
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDTO>>
    {
    }
}
