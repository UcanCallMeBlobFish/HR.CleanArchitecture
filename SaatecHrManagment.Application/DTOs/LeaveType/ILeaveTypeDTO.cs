using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveType
{
    public interface ILeaveTypeDTO
    {
        public string Name { get; set; } 
        public int DefaultDays { get; set; }
    }
}
