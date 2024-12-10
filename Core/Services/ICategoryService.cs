using BackEnd_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        IQueryable<Category> Where(Expression<Func<Category, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<Category, bool>> expression);
        Task AddRangeAsync(IEnumerable<Category> entities);
        Task<Category> AddAsync(Category entity);
        void UpdateAsync(Category entity);

        void RemoveAsync(Category entity);
        void RemoveRangeAsync(IEnumerable<Category> entities);
    }
}
