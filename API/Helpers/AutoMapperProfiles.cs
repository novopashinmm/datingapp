using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(x => x.PhotoUrl, 
                    c => 
                        c.MapFrom(x => x.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(x => x.Age, c => c.MapFrom(
                    x => x.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
        }
    }
}