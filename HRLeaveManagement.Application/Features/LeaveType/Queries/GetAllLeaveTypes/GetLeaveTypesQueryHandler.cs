using AutoMapper;
using HRLeaveManagement.Application.Contracts.Presistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypesQueryHandler(IMapper mapper , ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            var LeaveTypes = await _leaveTypeRepository.GetAllAsync();

            var dto = _mapper.Map<List<LeaveTypeDto>>(LeaveTypes);

            return dto;
        }
    }
}
