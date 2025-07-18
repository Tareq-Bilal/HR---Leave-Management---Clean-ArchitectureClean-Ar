using AutoMapper;
using HRLeaveManagement.Application.Contracts.Presistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand , Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper , ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

            //Vlidation

            // Map updated values — do not map the whole object!
            leaveType.Name = request.Name;
            leaveType.DefaultDays = request.DefaultDays;

            await _leaveTypeRepository.UpdateAsync(leaveType);

            return Unit.Value;
        }
    }
}
