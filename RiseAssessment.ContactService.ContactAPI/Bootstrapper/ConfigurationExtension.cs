using MediatR;
using Microsoft.EntityFrameworkCore;
using RiseAssessment.ContactService.Core.Gateways;
using RiseAssessment.ContactService.Core.Gateways.ContactService;
using RiseAssessment.ContactService.Core.Subscribers.Reports;
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
            services.AddTransient<CreateReportSubscriber>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IRestService, RestService>();
            services.AddSingleton<IReportGateway, ReportGateway>();


            #endregion


            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCap(options =>
            {
                options.UseEntityFramework<ContactDbContext>();
                options.UsePostgreSql(Configuration.GetConnectionString("DevelopmentDbConnection"));
                options.UseRabbitMQ(a =>
                {
                    a.HostName = Configuration.GetSection("RabbitMQHost:HostName").Value;
                    a.UserName = Configuration.GetSection("RabbitMQHost:UserName").Value;
                    a.Password = Configuration.GetSection("RabbitMQHost:Password").Value;
                });
                options.UseDashboard();

            });

            return services;
        }
    }
}
