using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Contracts.Presistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeNameUnique(string  leaveTypeName);
    }
}
