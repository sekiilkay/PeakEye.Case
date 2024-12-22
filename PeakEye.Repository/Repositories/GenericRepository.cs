using Microsoft.EntityFrameworkCore;
using PeakEye.Repository.Context;
using System.Linq.Expressions;

namespace PeakEye.Repository.Repositories
{
    public class GenericRepository<T>(PeakEyeContext context) : IGenericRepository<T> where T : class
    {
        protected readonly PeakEyeContext Context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();
        public async Task CreateAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => (await _dbSet.FindAsync(id))!;

        public void Update(T entity) => _dbSet.Update(entity);

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);
    }
}
