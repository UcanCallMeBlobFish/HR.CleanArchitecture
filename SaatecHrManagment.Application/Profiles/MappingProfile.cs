using AutoMapper;
using SaatecHrManagment.Application.DTOs.LeaveAllocation;
using SaatecHrManagment.Application.DTOs.LeaveRequest;
using SaatecHrManagment.Application.DTOs.LeaveType;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDTO>().ReverseMap();
            CreateMap<LeaveAllocation, CreateleaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDTO>().ReverseMap();



        }
    }
}
