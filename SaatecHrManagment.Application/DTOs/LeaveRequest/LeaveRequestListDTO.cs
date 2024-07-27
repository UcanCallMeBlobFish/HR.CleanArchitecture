using SaatecHrManagment.Application.DTOs.LeaveType;
using SaatecHrManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDTO : BaseEntityDTO
    {

        public LeaveTypeDTO? LeaveType { get; set; }

        public DateTime DateRequested { get; set; }

        public bool? Approved { get; set; }

    }
}
