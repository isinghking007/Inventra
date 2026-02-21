using Inventra.Application.DTOs;
using Inventra.Application.Services;
using Inventra.Domain.Entities;
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

        #region Post Methods
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

        #endregion Post Methods

        #region Get Methods

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductsByID(int id)
        {
            try
            {
                var productDetails =await _productService.GetProductIDAsync(id);
                return Ok(productDetails);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? searchTerm=null )
        {
            try
            {
                var result = await _productService.GetProductsAsync(pageNumber, pageSize,searchTerm);
                return Ok(result);

            }
            catch(Exception ex)
                {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("getbyProductSKU/{sku}")]
        public async Task<IActionResult> GetProductBySKU(string sku)
        {
            try
            {
                var productDetails = await _productService.GetProductBySKU(sku);
                if(productDetails == null)
                {
                    return NotFound(new { Message = "Invalid SKU, Product not found "+productDetails });
                }
                return Ok(productDetails);
            }
            catch(Exception ex)
            {
                return BadRequest(new {Message = ex.Message });
            }
        }

        #endregion Get Methods

        #region Put Methods
         [HttpPut("updateStock/{id}")]
         public async Task<IActionResult> UpdateProductDetail(int id, [FromBody] string productName, int newPrice, int newStockQuantity)
        {
            try
            {
                var result = await _productService.UpdateProductDetails(id, productName, newPrice, newStockQuantity);
                if (result !=null)
                {
                    return Ok(new { Message = "Product details updated successfully." });
                }
                else
                {
                    return NotFound(new { Message = "Product not found." });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        #endregion Put Methods

        #region Patch Methods
        [HttpPatch("updateProduct/{id}")]
        public async Task<IActionResult> UpdateProductDetails(int id, [FromBody] UpdateProductDTO updateProduct)
        {
            try
            {
                var result = await _productService.UpdateProductDetails(id, updateProduct);
                if(result == null)
                {
                    return NotFound(new { Message = "Product Not found" });
                }
                return Ok(new { Message = result});
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPatch("makeInActive/{id}")]
        public async Task<IActionResult> MakeInActiveProduct(int id)
        {
            try
            {
                var result = await _productService.MakeInActiveProduct(id);
                if (result == null)
                {
                    return NotFound(new { Message = "Product Not found" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
            #endregion Patch Methods
        }
}
