using BackEnd_Task.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<Product> entities)
        {
            var dataList = entities.ToList();
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException($"{typeof(Category).Name} not found");
            }
            return product;
        }

        public void Remove(Product entity)
        {
              _repository.Remove(entity);
        }

        public void RemoveRangeAsync(IEnumerable<Product> entities)
        {
            _repository.RemoveRange(entities);
        }

        public void UpdateAsync(Product entity)
        {
            _repository.Update(entity);
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
