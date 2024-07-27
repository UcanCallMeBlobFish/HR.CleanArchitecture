using System;
using System.Collections.Generic;
using System.Text;
using SaatecHrManagment.Domain.Common;

namespace SaatecHrManagment.Domain
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
