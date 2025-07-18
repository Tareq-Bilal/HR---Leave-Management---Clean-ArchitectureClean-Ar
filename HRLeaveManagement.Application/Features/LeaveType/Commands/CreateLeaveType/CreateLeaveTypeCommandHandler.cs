using AutoMapper;
using HRLeaveManagement.Application.Contracts.Presistence;
using HRLeaveManagement.Application.Excpetions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand , Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper , ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestExcpetion("Invaild Leave Type Input", validationResult);

            var leaveType = _mapper.Map<Domain.LeaveType>(request);
            await _leaveTypeRepository.CreateAsync(leaveType);

            return Unit.Value;
        }

    }
}
