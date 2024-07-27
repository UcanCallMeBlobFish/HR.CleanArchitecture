using SaatecHrManagment.Application.DTOs.LeaveType;
using SaatecHrManagment.Domain;
using SaatecHrManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDTO : BaseEntityDTO, ILeaveAllocationDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDTO? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
