using BackEnd_Task.Models;
using Core.Dto_s;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Repositories;
using Service.Exceptions;
using System.Linq.Expressions;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork, ICacheService cacheService, ILogger<ProductService> logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
            _logger = logger;
        }
        public async Task<Response<Product>> AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            _logger.LogInformation("Product with ID {ProductId} added successfully", entity.Id);
            return Response<Product>.Success(entity, 200);
        }

        public async Task<Response<IEnumerable<Product>>> GetAllAsync()
        {
            const string cacheKey = "products_all";
            var cachedProducts = await _cacheService.GetAsync<IEnumerable<Product>>(cacheKey);

            if (cachedProducts != null)
            {
                _logger.LogInformation("Products found in cache for key {CacheKey}", cacheKey);
                return Response<IEnumerable<Product>>.Success(cachedProducts, 200);
            }

            var products = await _repository.GetAllAsync();
            await _cacheService.SetAsync(cacheKey, products.Data, TimeSpan.FromMinutes(10));
            return Response<IEnumerable<Product>>.Success(products.Data, 200);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var cacheKey = $"product_{id}";
            var cachedProduct = await _cacheService.GetAsync<Product>(cacheKey);

            if (cachedProduct != null)
            {
                _logger.LogInformation("Product with ID {ProductId} found in cache", id);
                return cachedProduct;
            }

            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                _logger.LogWarning("Product with ID {ProductId} not found", id);
                throw new NotFoundException($"{typeof(Category).Name} not found");
            }

            await _cacheService.SetAsync(cacheKey, product, TimeSpan.FromMinutes(10));

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
