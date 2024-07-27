using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveRequests.Request.Command
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public UpdateLeaveRequestDTO UpdateLeaveRequestDTO { get; set; }
    }
}
