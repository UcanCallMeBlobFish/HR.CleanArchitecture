using Microsoft.EntityFrameworkCore;
using SaatecHrManagment.Application.Persistence.Contracts;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaatecHrManagment.Persistence.Repositories
{
    public class LeaveRequestRepository: GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly SaatecDbContext _context;
        public LeaveRequestRepository(SaatecDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var items = await _context
                .LeaveRequests
                .Include(a => a.LeaveType)
                .ToListAsync();

            return items;
        }

       
        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var item = await _context.LeaveRequests.Include(a => a.LeaveType).FirstOrDefaultAsync(a => a.Id == id);

            return item;
        }
    }
}
