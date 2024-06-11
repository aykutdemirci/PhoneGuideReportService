using Microsoft.EntityFrameworkCore;
using PhoneGuideReportService.Domain.Entities;

namespace PhoneGuideReportService.Persistance.Context
{
    public class PhoneGuideReportDbContext : DbContext
    {
        public PhoneGuideReportDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Report> Reports { get; set; }
    }
}
