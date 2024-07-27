using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Features.LeaveRequests.Request.Query
{
    public class GetleaveRequestDetailRequest : IRequest<LeaveRequestDTO>
    {
        public int Id { get; set; }
    }
}
