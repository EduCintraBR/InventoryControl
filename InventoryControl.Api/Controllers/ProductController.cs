using InventoryControl.Api.Models.Dto;
using InventoryControl.Api.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControl.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAll();

            if (!result.IsSuccess) return new BadRequestObjectResult(result.Message);

            return new OkObjectResult(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.Get(id);

            if (!result.IsSuccess) return new BadRequestObjectResult(result.Message);

            return new OkObjectResult(result);
        }
    }
}
