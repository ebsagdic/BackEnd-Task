using BackEnd_Task.Models;
using Core.Dto_s;
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
        Task<Response<IEnumerable<Product>>> GetAllAsync();
        Task<Response<Product>> AddAsync(Product entity);
        Response<NoDataDto> Update(Product product);
        Response<NoDataDto> Remove(int id);
    }
}
