using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Shemshad.Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<School,SchoolDto>()
                .ForMember(s => s.FullAddress,
                    opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
            CreateMap<Student, StudentDto>();
        }
    }
}
