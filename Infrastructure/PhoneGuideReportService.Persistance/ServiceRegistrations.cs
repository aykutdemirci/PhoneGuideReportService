using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneGuideReportService.Application.Abstractions.Services;
using PhoneGuideReportService.Application.Abstractions.UnitOfWork;
using PhoneGuideReportService.Application.Repositories;
using PhoneGuideReportService.Persistance.Configurations;
using PhoneGuideReportService.Persistance.Context;
using PhoneGuideReportService.Persistance.Repositories;
using PhoneGuideReportService.Persistance.Services;

namespace PhoneGuideReportService.Persistance
{
    public static class ServiceRegistrations
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddDbContext<PhoneGuideReportDbContext>(opts => opts.UseNpgsql(ConnectionStrings.PostgreSQL));

            services.AddScoped<IReportService, ReportService>();
        }
    }
}
