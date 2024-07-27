using Microsoft.EntityFrameworkCore;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Persistence
{
    public class SaatecDbContext : DbContext
    {
        public SaatecDbContext(DbContextOptions<SaatecDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaatecDbContext).Assembly);

        }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }


    }
}
