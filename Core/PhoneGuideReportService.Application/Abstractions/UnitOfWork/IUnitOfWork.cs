using PhoneGuideReportService.Application.Repositories;

namespace PhoneGuideReportService.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IReportRepository ReportRepository { get; }

        Task SaveAsync();
    }
}
