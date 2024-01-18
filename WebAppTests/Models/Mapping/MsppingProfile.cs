using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebAppTests.Data.Identity;

namespace WebAppTests.Models.Mapping
{
    public class MsppingProfile : Profile
    {
        public MsppingProfile() 
        {
            this.CreateMap<ApplicationIdentityUser, StudentModels>()
                .ForMember(dtc => dtc.Name, 
                opt => opt.MapFrom(src => src.Name.ToLower()))
                .ForMember(dtc => dtc.FullName, opt =>
                opt.MapFrom(src => src.Name + " " + src.LastName));// из Student в StudentModels
            this.CreateMap<StudentModels, ApplicationIdentityUser>();
        }
    }
}
