using BackEnd_Task.Models;
using Core.Dto_s;
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
        public async Task<Response<Category>> AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync();
            return Response<Category>.Success(category, 200);
        }

        public async Task<Response<IEnumerable<Category>>> GetAllAsync()
        {
            var category = await _categoryRepository.GetAllAsync();
            return Response<IEnumerable<Category>>.Success(category.Data, 200);

        }
    }
}
