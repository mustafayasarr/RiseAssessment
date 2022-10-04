using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseAssessment.ReportService.Core.Gateways;
using RiseAssessment.ReportService.Core.Gateways.ContactService;
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

            #region Lifetime
        
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IRestService, RestService>();
            services.AddSingleton<IContactGateway, ContactGateway>();

            #endregion


            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


            return services;
        }
    }
}
