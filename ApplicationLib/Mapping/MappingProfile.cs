using ApplicationLib.DTOs.User;
using AutoMapper;
//using DomainLib.Models;
using Microsoft.AspNetCore.Identity;

namespace ApplicationLib.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map UserRegisterDTO to IdentityUser
            CreateMap<UserRegisterDTO, IdentityUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            //// IdentityUser to User domain entity
            //CreateMap<IdentityUser, User>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // IdentityUser to UserDTO
            CreateMap<IdentityUser, UserDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
