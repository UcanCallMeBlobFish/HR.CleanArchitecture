using SaatecHrManagment.Application.Persistence.Contracts;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaatecHrManagment.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly SaatecDbContext _context;
        public LeaveTypeRepository(SaatecDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

