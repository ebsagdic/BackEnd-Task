using BackEnd_Task.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MongoContext _context;

        public ProductRepository(MongoContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product entity)
        {
            await _context.Products.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Product> entities)
        {
            await _context.Products.InsertManyAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            var count = await _context.Products.CountDocumentsAsync(expression);
            return count > 0;
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products.AsQueryable();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public void Remove(Product entity)
        {
            _context.Products.DeleteOneAsync(p => p.Id == entity.Id);
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            var ids = entities.Select(e => e.Id).ToList();
            _context.Products.DeleteManyAsync(p => ids.Contains(p.Id));
        }

        public void Update(Product entity)
        {
            _context.Products.ReplaceOneAsync(p => p.Id == entity.Id, entity);
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _context.Products.AsQueryable().Where(expression);
        }
    }
}
