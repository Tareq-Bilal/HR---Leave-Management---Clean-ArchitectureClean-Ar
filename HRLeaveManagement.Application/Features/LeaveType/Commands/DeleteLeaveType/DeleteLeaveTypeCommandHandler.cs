using AutoMapper;
using HRLeaveManagement.Application.Contracts.Presistence;
using HRLeaveManagement.Application.Excpetions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if (leaveTypeToDelete == null)
                throw new NotFoundExcption(nameof(leaveTypeToDelete), request.Id);

            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            return Unit.Value;
        }
    }
}
