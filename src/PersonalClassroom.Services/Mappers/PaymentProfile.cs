using AutoMapper;
using PersonalClassroom.Database.Entities;
using PersonalClassroom.Services.Models;
using System.Linq;

namespace PersonalClassroom.Services.Mappers
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentGridModel>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Date, x => x.MapFrom(y => y.Date))
                .ForMember(x => x.Price, x => x.MapFrom(y => y.Price))
                .ForMember(x => x.ForStudentIds, x => x.MapFrom(y => y.StudentPayments.Select(z => (int?)z.StudentId)));
        }
    }
}
