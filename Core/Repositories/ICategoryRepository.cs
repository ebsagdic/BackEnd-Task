using BackEnd_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        IQueryable<Category> GetAll();
        IQueryable<Category> Where(Expression<Func<Category, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<Category, bool>> expression);
        Task AddRangeAsync(IEnumerable<Category> entities);
        Task AddAsync(Category entity);
        void Update(Category entity);
        void Remove(Category entity);
        void RemoveRange(IEnumerable<Category> entities);
    }
}
