using BackEnd_Task.Models;
using Core.Dto_s;
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
        public async Task<Response<Category>> AddAsync(Category category)
        {
            await _dbSet.AddAsync(category);
            return Response<Category>.Success(category, 201);
        }
        public async Task<Response<IQueryable<Category>>> GetAllAsync()
        {
            var categories = _dbSet.AsNoTracking().AsQueryable();
            return await Task.FromResult(Response<IQueryable<Category>>.Success(categories, 200)); ;
        }
    }
}
