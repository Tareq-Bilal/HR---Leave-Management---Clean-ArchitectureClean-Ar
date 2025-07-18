using HRLeaveManagement.Application.Contracts.Presistence;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Presistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Presistence.Repository
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest> , ILeaveRequestRepository
    {

        public LeaveRequestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            return await _context.LeaveRequests
                                 .Include(x => x.LeaveType)
                                 .ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            return await _context.LeaveRequests
                                 .Include(x => x.LeaveType)
                                 .Where(x => x.RequestingEmployeeId == userId)
                                 .ToListAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            return await _context.LeaveRequests
                                 .Include(x => x.LeaveType)
                                 .FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}
