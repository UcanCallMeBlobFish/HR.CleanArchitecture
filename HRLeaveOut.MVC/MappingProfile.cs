using AutoMapper;
using HRLeaveOut.MVC.Models;
using HRLeaveOut.MVC.Services.Base;

namespace HRLeaveOut.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDTO, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDTO, LeaveTypeVM>().ReverseMap();
            CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();


        }

    }
}
