using MediatR;
using SaatecHrManagment.Application.CustomResponse;
using SaatecHrManagment.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveRequests.Request.Command
{
    public class CreateLeaveRequestCommand : IRequest<CustomResponser>
    {
        public CreateLeaveRequestDTO CreateLeaveRequestDTO { get; set; }
    }
}
