using Microsoft.EntityFrameworkCore;
using PhoneGuideReportService.Domain.Entities.Common;

namespace PhoneGuideReportService.Application.Repositories
{
    public interface IReport<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        Task<bool> AddAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteByIdAsync(Guid id);

        Task<IQueryable<T>> GetAllAsync();
    }
}
