using Microsoft.EntityFrameworkCore;
using PhoneGuideReportService.Domain.Entities.Common;

namespace PhoneGuideReportService.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        Task<bool> AddAsync(T entity);

        bool Update(T entity);

        Task<bool> DeleteByIdAsync(string id);

        IQueryable<T> GetAll(bool tracking = false);

        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
