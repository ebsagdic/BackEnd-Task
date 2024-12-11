using BackEnd_Task.Models;
using Core.Services;
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
        public async Task<IActionResult> GetAllProduct()
        {
            return ActionResultInstance(await _productService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(Product product)
        {
            return ActionResultInstance(await _productService.AddAsync(product));
        }

        [HttpPut]
        public  IActionResult Update(Product product)
        {
            return ActionResultInstance( _productService.Update(product));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            return ActionResultInstance( _productService.Remove(id));
        }

    }
}
