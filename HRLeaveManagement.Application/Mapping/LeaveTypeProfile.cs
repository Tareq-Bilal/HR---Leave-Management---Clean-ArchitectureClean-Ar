using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetail;
using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Mapping
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto , LeaveType>().ReverseMap();
            CreateMap<LeaveTypeDetailsDto , LeaveType>().ReverseMap();
        }
    }
}
