using ContactBookWebApp.Infrastructure.Persistence;
using ContactBookWebApp.Infrastructure.RepositoryBase.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookWebApp.Infrastructure.RepositoryBase.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context.Set<T>();
        }

        public void Create(T entity) => _context.Add(entity);

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public void Delete(T entity) => _context.Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ?
            _context.AsNoTracking():
            _context;

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ?
            _context.Where(expression).AsNoTracking() :
            _context.Where(expression);

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);

        }

        public void Update(T entity) => _context.Update(entity);
    }
}
