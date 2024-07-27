using SaatecHrManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveRequest
{
    public class ChangeleaveRequestApprovalDTO : BaseEntityDTO
    {
        public bool? Approved { get; set; }
    }
}
