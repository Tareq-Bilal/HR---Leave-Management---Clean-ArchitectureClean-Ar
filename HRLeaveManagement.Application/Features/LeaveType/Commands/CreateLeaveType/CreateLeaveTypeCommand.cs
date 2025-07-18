using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
