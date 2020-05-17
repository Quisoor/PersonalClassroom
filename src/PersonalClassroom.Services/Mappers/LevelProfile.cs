using AutoMapper;
using PersonalClassroom.Database.Entities;
using PersonalClassroom.Services.Models;

namespace PersonalClassroom.Services.Mappers
{
    public class LevelProfile : Profile
    {
        public LevelProfile()
        {
            CreateMap<Level, ShortModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Label, x => x.MapFrom(y => y.Symbol));
        }
    }
}
