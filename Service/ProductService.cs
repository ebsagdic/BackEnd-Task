using BackEnd_Task.Models;
using Core.Dto_s;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Service.Exceptions;
using System.Linq.Expressions;

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
        public async Task<Response<Product>> AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return Response<Product>.Success(entity, 200);
        }

        public async Task<Response<IEnumerable<Product>>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return Response<IEnumerable<Product>>.Success(products.Data, 200);
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

        public Response<NoDataDto> Remove(int id)
        {
             return  _repository.Remove(id);
        }
        public Response<NoDataDto> Update(Product product)
        {
            return _repository.Update(product);
        }
    }
}
