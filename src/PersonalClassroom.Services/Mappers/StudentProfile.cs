using AutoMapper;
using PersonalClassroom.Database.Entities;
using PersonalClassroom.Services.Models;

namespace PersonalClassroom.Services.Mappers
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            this.CreateMap<Student, ShortModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Label, x => x.MapFrom(y => $"{y.Firstname} {y.Lastname}"));
            this.CreateMap<Student, StudentGridModel>().ReverseMap();
        }
    }
}
