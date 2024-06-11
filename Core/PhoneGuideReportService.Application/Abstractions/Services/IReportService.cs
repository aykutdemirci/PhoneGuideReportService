using PhoneGuideReportService.Application.Dto;

namespace PhoneGuideReportService.Application.Abstractions.Services
{
    public interface IReportService
    {
        Task<bool> CreateAsync(DtoReport dtoCreateReport);

        Task<List<DtoReport>> GetAllAsync();
    }
}
