

using AutoMapper;
using patota_manager_api.src.PatotaManager.Api.DTOs;
using patota_manager_api.src.PatotaManager.Api.Models;

namespace patota_manager_api.src.PatotaManager.Infrastructure.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<User, UserDTO>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash));
        }
    }
}