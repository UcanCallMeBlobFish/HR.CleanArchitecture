using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveTypes.Requests.Command
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public LeaveTypeDTO LeaveTypeDTO { get; set; }

    }
}
