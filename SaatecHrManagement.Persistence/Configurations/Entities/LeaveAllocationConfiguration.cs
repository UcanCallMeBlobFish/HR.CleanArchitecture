﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaatecHrManagement.Persistence.Configurations.Entities
{
    public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
    {
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
        }
    }
}
