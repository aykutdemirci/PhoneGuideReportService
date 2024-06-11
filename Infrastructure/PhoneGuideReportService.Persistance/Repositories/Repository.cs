using Microsoft.EntityFrameworkCore;
using PhoneGuideReportService.Application.Repositories;
using PhoneGuideReportService.Domain.Entities.Common;
using PhoneGuideReportService.Persistance.Context;

namespace PhoneGuideReportService.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PhoneGuideReportDbContext _dbContext;

        public Repository(PhoneGuideReportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            var entityEntry = await Table.AddAsync(entity);

            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            var entity = await GetByIdAsync(id);

            var entityEntry = Table.Remove(entity);

            return entityEntry.State == EntityState.Deleted;
        }

        public IQueryable<T> GetAll(bool tracking = false)
        {
            var queryable = Table.AsQueryable();

            if (!tracking) queryable = queryable.AsNoTracking();

            return queryable;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var queryable = Table.AsQueryable();

            if (!tracking) queryable = queryable.AsNoTracking();

            return await queryable.FirstOrDefaultAsync(q => q.Id == Guid.Parse(id));
        }

        public bool Update(T entity)
        {
            var entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
