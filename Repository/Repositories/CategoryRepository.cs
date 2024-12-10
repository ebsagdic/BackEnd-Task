using BackEnd_Task.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }
        public async Task AddAsync(Category entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Category> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<Category, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<Category> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(Category entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(Category entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<Category> Where(Expression<Func<Category, bool>> expression)
        {
            return _dbSet.Where(expression).AsQueryable();
        }
    }
}
