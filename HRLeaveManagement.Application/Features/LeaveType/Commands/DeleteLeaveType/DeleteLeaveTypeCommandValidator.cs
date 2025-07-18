using FluentValidation;
using HRLeaveManagement.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandValidator : AbstractValidator<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository) { 
            
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(l => l.Id)
                .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0")
                .MustAsync(LeaveTypeExist).WithMessage("This {PropertyName} already exist");

        }
        private async Task<bool> LeaveTypeExist(int id, CancellationToken token)
        {
            return await _leaveTypeRepository.GetByIdAsync(id) != null;
        }
    }
}
