using BackEnd_Task.Models;
using Core.Dto_s;
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
        public async Task<Response<Product>> AddAsync(Product entity)
        {
            await _context.Products.InsertOneAsync(entity);
            return Response<Product>.Success(entity, 201);
        }
        public async Task<Response<IEnumerable<Product>>> GetAllAsync()
        {
            var products = _context.Products.AsQueryable(); 
            return await Task.FromResult(Response<IEnumerable<Product>>.Success(products, 200)); 
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public Response<NoDataDto> Remove(int id)
        {
            var deleteResult =  _context.Products.DeleteOne(p => p.Id == id);

            if (deleteResult.DeletedCount > 0)
            {
                return Response<NoDataDto>.Success(204); 
            }
            return Response<NoDataDto>.Fail("Product not found or could not be deleted.", 404, true); 
        }

        public Response<NoDataDto> Update(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);

            var result = _context.Products.ReplaceOne(filter, product);

            if (result.ModifiedCount > 0)
            {
                return Response<NoDataDto>.Success(204); // 204 No Content
            }
            return Response<NoDataDto>.Fail("Product not found or could not be updated.", 404, true); // 404 Not Found
        }
    }
}
