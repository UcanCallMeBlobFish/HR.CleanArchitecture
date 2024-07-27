using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveTypes.Requests.Command
{
    public class CreateLeaveTypeRequest : IRequest<int>
    {
        public CreateLeaveTypeDTO CreateLeaveTypeDTO { get; set; }

    }
}
