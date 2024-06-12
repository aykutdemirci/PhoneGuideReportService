using PhoneGuideReportService.Application.Dto.Report;

namespace PhoneGuideReportService.Application.Abstractions.Services
{
    public interface IReportService
    {
        Task<Guid> CreateAsync(DtoCreateReport dtoCreateReport);

        Task<List<DtoDisplayReport>> GetAllAsync();

        Task<DtoDisplayReport> GetByIdAsync(Guid id);
    }
}
