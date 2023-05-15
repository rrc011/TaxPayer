using Microsoft.EntityFrameworkCore;
using TaxPayers.Application;
using TaxPayers.Domain.Common;
using TaxPayers.Persistence.Contexts;

namespace TaxPayers.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
    {
        private readonly TaxPayerDbContext _dbContext;

        public GenericRepository(TaxPayerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>().Where(x => !x.IsDeleted);

        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            T exist = _dbContext.Set<T>().Find(entity.Id);
            exist.UpdatedDate = DateTime.Now;
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }

        public Task HardDeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
        public Task DeleteAsync(T entity)
        {
            T exist = _dbContext.Set<T>().Find(entity.Id);
            exist.IsDeleted = true;
            exist.UpdatedDate = DateTime.Now;
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
