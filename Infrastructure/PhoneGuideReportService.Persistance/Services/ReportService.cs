using Microsoft.EntityFrameworkCore;
using PhoneGuide.Application.Dto.Report;
using PhoneGuideReportService.Application.Abstractions.Services;
using PhoneGuideReportService.Application.Abstractions.UnitOfWork;
using PhoneGuideReportService.Domain.Entities;
using PhoneGuideReportService.Domain.Enums;

namespace PhoneGuideReportService.Persistance.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(DtoCreateReport dtoCreateReport)
        {
            var added = await _unitOfWork.ReportRepository.AddAsync(new Report
            {
                RequestedDate = dtoCreateReport.RequestedDate,
                ReportStatus = dtoCreateReport.ReportStatus,
            });

            if (added) await _unitOfWork.SaveAsync();

            return added;
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
    }
}
