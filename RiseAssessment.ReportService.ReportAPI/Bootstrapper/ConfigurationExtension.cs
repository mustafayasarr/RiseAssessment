using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseAssessment.ReportService.Infrastructure.Context;
using RiseAssessment.ReportService.Infrastructure.Repositories.Abstract;
using RiseAssessment.ReportService.Infrastructure.Repositories.Concrete;

namespace RiseAssessment.ReportService.ReportAPI.Bootstrapper
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection RegisterConfigurationServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ContactDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DevelopmentDbConnection")));

            #region Repository
        
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion


            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


            return services;
        }
    }
}
