using Microsoft.EntityFrameworkCore;
using PhoneGuideReportService.Domain.Entities;
using PhoneGuideReportService.Domain.Entities.Common;

namespace PhoneGuideReportService.Persistance.Context
{
    public class PhoneGuideReportDbContext : DbContext
    {
        public PhoneGuideReportDbContext(DbContextOptions options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Report> Reports { get; set; }
    }
}
