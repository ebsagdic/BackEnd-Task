using BackEnd_Task.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Viewer")]
        public async Task<IActionResult> GetAllProduct()
        {
            return ActionResultInstance(await _productService.GetAllAsync());
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> SaveProduct(Product product)
        {
            return ActionResultInstance(await _productService.AddAsync(product));
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Manager")]
        public  IActionResult Update(Product product)
        {
            return ActionResultInstance( _productService.Update(product));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Remove(int id)
        {
            return ActionResultInstance( _productService.Remove(id));
        }

    }
}
