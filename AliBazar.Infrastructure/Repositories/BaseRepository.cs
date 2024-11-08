using AliBazar.Application.Abstractions;
using AliBazar.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;

namespace AliBazar.Infrastructure.Repositories
{
    public class BaseRepository<T>(AliBazarDbContext context) : IBaseRepository<T> 
        where T : class
    {
        private readonly AliBazarDbContext _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T> Create(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            var res = await _dbSet.FirstOrDefaultAsync(expression);
            if (res == null)
            {
                return false;
            }

            _dbSet.Remove(res);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByAny(Expression<Func<T, bool>> expression)
        {
            try
            {
                var res = await _dbSet.FirstOrDefaultAsync(expression) ?? throw new Exception();
                return res;
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            var result = _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
