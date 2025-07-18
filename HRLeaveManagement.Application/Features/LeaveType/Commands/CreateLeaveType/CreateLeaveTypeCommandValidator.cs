using FluentValidation;
using HRLeaveManagement.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand> 
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository) {

            _leaveTypeRepository = leaveTypeRepository;
            
            RuleFor(l => l.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

            RuleFor(p => p.DefaultDays)
                .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
                .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

            RuleFor(l => l.Name)
                .MustAsync(LeavTypeNameUnique).WithMessage("{PropertyName} should be unique");
        }
        
        private async Task<bool> LeavTypeNameUnique(string leaveTypeName, CancellationToken token)
        {
            return await _leaveTypeRepository.IsLeaveTypeNameUnique(leaveTypeName);
        }
    }
}
