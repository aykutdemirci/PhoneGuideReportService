using PhoneGuideReportService.Application.Abstractions.UnitOfWork;
using PhoneGuideReportService.Application.Repositories;
using PhoneGuideReportService.Persistance.Context;

namespace PhoneGuideReportService.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public IReportRepository ReportRepository { get; }

        private readonly PhoneGuideReportDbContext _dbContext;

        public UnitOfWork(IReportRepository reportRepository, PhoneGuideReportDbContext dbContext)
        {
            _dbContext = dbContext;
            ReportRepository = reportRepository;
        }

        public async Task SaveAsync()
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
