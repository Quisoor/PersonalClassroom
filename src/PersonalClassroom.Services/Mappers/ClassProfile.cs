using AutoMapper;
using PersonalClassroom.Database.Entities;
using PersonalClassroom.Services.Models;

namespace PersonalClassroom.Services.Mappers
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassGridModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Date, x => x.MapFrom(y => y.Start))
                .ForMember(x => x.Duration, x => x.MapFrom(y => y.Duration))
                .ForMember(x => x.StudentId, x => x.MapFrom(y => y.StudentId))
                .ForMember(x => x.Price, x => x.MapFrom(y => y.Price))
                .ForMember(x => x.LeftToPay, x => x.MapFrom(y => y.LeftToPay))
                .ReverseMap();
        }
    }
}
