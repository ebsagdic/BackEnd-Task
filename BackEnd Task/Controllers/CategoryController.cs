using BackEnd_Task.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace BackEnd_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Viewer")]
        public async Task<IActionResult> GetAllCategory()
        {
            return ActionResultInstance(await _categoryService.GetAllAsync());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            return ActionResultInstance(await _categoryService.AddAsync(category));
        }

    }
}
