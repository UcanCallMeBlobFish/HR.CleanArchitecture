﻿using SaatecHrManagment.Application.DTOs.LeaveType;
using SaatecHrManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDTO : BaseEntityDTO, ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string? RequestComments { get; set; }
        public bool Cancelled { get; set; }
    }
}
