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
    public interface ICategoryRepository
    {
        Task<Response<IQueryable<Category>>> GetAllAsync();
        Task<Response<Category>> AddAsync(Category entity);
    }
}
