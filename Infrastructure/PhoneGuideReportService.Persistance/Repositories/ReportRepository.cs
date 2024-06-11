using PhoneGuideReportService.Application.Repositories;
using PhoneGuideReportService.Domain.Entities;
using PhoneGuideReportService.Persistance.Context;

namespace PhoneGuideReportService.Persistance.Repositories
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(PhoneGuideReportDbContext dbContext) : base(dbContext)
        {
        }
    }
}
