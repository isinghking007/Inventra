using Inventra.Application.DTOs;
using Inventra.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventra.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct(ProductDetailsDTO productDetails)
        {
            try
            {
               await _productService.AddNewProductAsync(productDetails);
                return Ok(new { Message = "Product added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
