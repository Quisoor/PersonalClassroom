using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PersonalClassroom.Services.Validators;

namespace PersonalClassroom.Services.Extensions
{
    public static class DependencyInjection
    {
        public static void AddPersonalClassroomServices(this IServiceCollection services)
        {
            //services
            services.AddTransient<ClassFormService>();
            services.AddTransient<ClassGridService>();
            services.AddTransient<LevelService>();
            services.AddTransient<PaymentFormService>();
            services.AddTransient<PaymentGridService>();
            services.AddTransient<StudentGridService>();
            services.AddTransient<StudentService>();

            //validators
            services.AddTransient<ClassFormValidator>();
            services.AddTransient<ClassGridValidator>();
            services.AddTransient<PaymentFormValidator>();
            services.AddTransient<PaymentGridValidator>();
            services.AddTransient<StudentGridValidator>();

            //notifiers
            services.AddScoped<ErrorService>();

            //mapper
            services.AddAutoMapper(typeof(DependencyInjection));
        }
    }
}
