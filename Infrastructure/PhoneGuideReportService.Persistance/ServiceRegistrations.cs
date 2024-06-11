using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneGuideReportService.Persistance.Configurations;
using PhoneGuideReportService.Persistance.Context;

namespace PhoneGuideReportService.Persistance
{
    public static class ServiceRegistrations
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<PhoneGuideReportDbContext>(opts => opts.UseNpgsql(ConnectionStrings.PostgreSQL));
        }
    }
}
