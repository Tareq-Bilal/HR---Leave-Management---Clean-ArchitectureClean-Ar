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
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation> , ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);  
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(x => x.EmployeeId == userId
                                                           && x.LeaveTypeId == leaveTypeId
                                                           && x.Period == period);

        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations
                                 .Include(x => x.LeaveType)
                                 .ToListAsync();
        
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocations = await _context.LeaveAllocations
                                  .Include(x => x.LeaveType)
                                  .Where(x => x.EmployeeId == userId)
                                  .ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocations =  await _context.LeaveAllocations
                                  .Include(x => x.LeaveType)
                                  .FirstOrDefaultAsync(x => x.Id == id);

            return leaveAllocations;

        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocations
                                 .FirstOrDefaultAsync(x => x.LeaveTypeId == leaveTypeId
                                                      && x.EmployeeId == userId);
                                 
        }
    }
}
