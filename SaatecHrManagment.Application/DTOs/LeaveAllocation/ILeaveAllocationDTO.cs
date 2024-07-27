using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveAllocation
{
    public interface ILeaveAllocationDTO 
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
