using BackEnd_Task.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;
using System.Linq.Expressions;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository , IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Category> AddAsync(Category entity)
        {
            await _categoryRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<Category> entities)
        {
            var dataList = entities.ToList();
            await _categoryRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Category, bool>> expression)
        {
            return await _categoryRepository.AnyAsync(expression);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAll().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var product = await _categoryRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException($"{typeof(Category).Name} not found");
            }
            return product;
        }

        public void RemoveAsync(Category entity)
        {
            _categoryRepository.Remove(entity);

        }

        public void RemoveRangeAsync(IEnumerable<Category> entities)
        {
            _categoryRepository.RemoveRange(entities);
        }

        public void UpdateAsync(Category entity)
        {
            _categoryRepository.Update(entity);
        }

        public IQueryable<Category> Where(Expression<Func<Category, bool>> expression)
        {
            return _categoryRepository.Where(expression);
        }
    }
}
