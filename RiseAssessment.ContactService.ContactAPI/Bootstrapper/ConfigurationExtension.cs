using Microsoft.EntityFrameworkCore;
using RiseAssessment.ContactService.Infrastructure.Context;

namespace RiseAssessment.ContactService.ContactAPI.Bootstrapper
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection RegisterConfigurationServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ContactDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DevelopmentDbConnection")));
        
            return services;
        }
    }
}
