using BackEnd_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        IQueryable<Product> GetAll();
        IQueryable<Product> Where(Expression<Func<Product, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<Product, bool>> expression);
        Task AddRangeAsync(IEnumerable<Product> entities);
        Task AddAsync(Product entity);
        void Update(Product entity);
        void Remove(Product entity);
        void RemoveRange(IEnumerable<Product> entities);
    }
}
