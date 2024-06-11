using PhoneGuide.Application.Dto.Report;

namespace PhoneGuideReportService.Application.Abstractions.Services
{
    public interface IReportService
    {
        Task<bool> CreateAsync(DtoCreateReport dtoCreateReport);

        Task<List<DtoDisplayReport>> GetAllAsync();
    }
}
