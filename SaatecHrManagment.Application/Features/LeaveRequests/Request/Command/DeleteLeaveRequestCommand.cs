using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveRequests.Request.Command
{
    public class DeleteLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
