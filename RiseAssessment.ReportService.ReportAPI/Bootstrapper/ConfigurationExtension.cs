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

            #region Lifetime
        
            services.AddScoped<IReportItemRepository, ReportItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
