using Microsoft.EntityFrameworkCore;
using PhoneGuideReportService.Application.Abstractions.Services;
using PhoneGuideReportService.Application.Abstractions.UnitOfWork;
using PhoneGuideReportService.Application.Dto;
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

        public async Task<bool> CreateAsync(DtoReport dtoCreateReport)
        {
            var added = await _unitOfWork.ReportRepository.AddAsync(new Report
            {
                RequestedDate = DateTime.UtcNow,
                ReportStatus = ReportStatus.Preparing,
            });

            if (added) await _unitOfWork.SaveAsync();

            return added;
        }

        public async Task<List<DtoReport>> GetAllAsync()
        {
            return await _unitOfWork.ReportRepository.GetAll().Select(q => new DtoReport
            {
                RequestedDate = q.RequestedDate,
                ReportStatus = q.ReportStatus,
            }).ToListAsync();
        }
    }
}
