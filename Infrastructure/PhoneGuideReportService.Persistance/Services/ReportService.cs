using Microsoft.EntityFrameworkCore;
using PhoneGuideReportService.Application.Abstractions.Services;
using PhoneGuideReportService.Application.Abstractions.UnitOfWork;
using PhoneGuideReportService.Application.Dto.Report;
using PhoneGuideReportService.Domain.Entities;

namespace PhoneGuideReportService.Persistance.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateAsync(DtoCreateReport dtoCreateReport)
        {
            var report = new Report
            {
                RequestedDate = dtoCreateReport.RequestedDate,
                ReportStatus = dtoCreateReport.ReportStatus,
            };

            var added = await _unitOfWork.ReportRepository.AddAsync(report);

            if (added) await _unitOfWork.SaveAsync();

            return report.Id;
        }

        public async Task<List<DtoDisplayReport>> GetAllAsync()
        {
            return await _unitOfWork.ReportRepository.GetAll().Select(q => new DtoDisplayReport
            {
                Id = q.Id.ToString(),
                RequestedDate = q.RequestedDate,
                ReportStatus = q.ReportStatus,
            }).ToListAsync();
        }

        public async Task<DtoDisplayReport> GetByIdAsync(Guid id)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(id.ToString(), false);
            return new DtoDisplayReport
            {
                Id = report.Id.ToString(),
                ReportStatus = report.ReportStatus,
                RequestedDate = report.RequestedDate,
            };
        }
    }
}
