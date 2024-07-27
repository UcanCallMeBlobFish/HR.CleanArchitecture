using SaatecHrManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveType
{
    public class LeaveTypeDTO : BaseEntityDTO, ILeaveTypeDTO
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
