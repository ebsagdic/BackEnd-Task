using BackEnd_Task.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        IQueryable<Product> Where(Expression<Func<Product, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<Product, bool>> expression);
        Task AddRangeAsync(IEnumerable<Product> entities);
        Task<Product> AddAsync(Product entity);
        void UpdateAsync(Product entity);

        void Remove(Product entity);
        void RemoveRangeAsync(IEnumerable<Product> entities);
    }
    
}
