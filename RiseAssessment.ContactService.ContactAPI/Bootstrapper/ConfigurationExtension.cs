using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseAssessment.ContactService.Infrastructure.Context;
using RiseAssessment.ContactService.Infrastructure.Repositories.Abstract;
using RiseAssessment.ContactService.Infrastructure.Repositories.Concrete;

namespace RiseAssessment.ContactService.ContactAPI.Bootstrapper
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection RegisterConfigurationServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ContactDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DevelopmentDbConnection")));

            #region Lifetime
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactInformationRepository, ContactInformationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion


            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


            return services;
        }
    }
}
