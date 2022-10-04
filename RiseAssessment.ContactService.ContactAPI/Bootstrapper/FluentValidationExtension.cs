using FluentValidation;
using FluentValidation.AspNetCore;
using RiseAssessment.ContactService.Domain.ActionFilter;
using RiseAssessment.ContactService.Domain.Models.Commands.Contact;

namespace RiseAssessment.ContactService.ContactAPI.Bootstrapper
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection RegisterFluentValidation(this IServiceCollection services)
        {
            services.AddControllersWithViews(option =>
            {
                option.Filters.Add(new ValidationFilter());
            }).AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
                conf.AutomaticValidationEnabled = false;
            });

            var types = typeof(CreateContactCommandValidator).Assembly.GetTypes();
            new AssemblyScanner(types).ForEach(pair =>
            {
                services.Add(ServiceDescriptor.Transient(pair.InterfaceType, pair.ValidatorType));
            });

            return services;
        }
    }
}
