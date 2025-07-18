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
    public class LeaveTypeRepository : GenericRepository<LeaveType> , ILeaveTypeRepository
    {

        public LeaveTypeRepository(AppDbContext context) : base(context){ 
        }

        public async Task<bool> IsLeaveTypeNameUnique(string leaveTypeName)
        {
            var result = await _context.LeaveTypes.FirstOrDefaultAsync(t => t.Name == leaveTypeName);

            return result == null;
        }
    }
}
