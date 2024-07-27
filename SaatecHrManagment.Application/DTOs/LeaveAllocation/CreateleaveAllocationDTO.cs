using SaatecHrManagment.Application.DTOs.LeaveType;
using SaatecHrManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveAllocation
{
    public class CreateleaveAllocationDTO : ILeaveAllocationDTO
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}

