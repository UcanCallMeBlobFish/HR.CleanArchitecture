using Microsoft.EntityFrameworkCore;
using SaatecHrManagment.Application.Persistence.Contracts;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaatecHrManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly SaatecDbContext _context;
        public LeaveAllocationRepository(SaatecDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }




        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var items = await _context
                           .LeaveAllocations
                           .Include(a => a.LeaveType)
                           .ToListAsync();

            return items;
        }

        public async  Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var item = await _context.LeaveAllocations.Include(a => a.LeaveType).FirstOrDefaultAsync(a => a.Id == id);

            return item;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(a => a.EmployeeId == userId && a.LeaveTypeId == leaveTypeId);
        }
    }
}
