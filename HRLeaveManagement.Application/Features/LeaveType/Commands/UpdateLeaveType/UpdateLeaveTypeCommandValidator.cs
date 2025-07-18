using FluentValidation;
using HRLeaveManagement.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(l => l.Id)
                .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0")
                .MustAsync(LeaveTypeExist).WithMessage("This {PropertyName} already exist");

            RuleFor(l => l.DefaultDays)
               .GreaterThan(100).WithMessage("{PropertyName} can't exceed 100")
               .LessThan(1).WithMessage("{PropertyName} can't be less than 1");

            RuleFor(l => l.Name)
                .MustAsync(LeavTypeNameUnique).WithMessage("{PropertyName} should be unique");
        }
        private async Task<bool> LeaveTypeExist(int id, CancellationToken token)
        {
            return await _leaveTypeRepository.GetByIdAsync(id) != null;
        }

        private async Task<bool> LeavTypeNameUnique(string leaveTypeName, CancellationToken token)
        {
            return await _leaveTypeRepository.IsLeaveTypeNameUnique(leaveTypeName);
        }
    }
}
