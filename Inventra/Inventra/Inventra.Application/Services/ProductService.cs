using Inventra.Application.DTOs;
using Inventra.Application.Interfaces;
using Inventra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Application.Services
{
    public class ProductService
    {
        private readonly IProductDetailsRepository _productRepository;
        public ProductService(IProductDetailsRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task AddNewProductAsync(ProductDetailsDTO productDetails)
        {
            if (productDetails == null)
            {
                throw new ArgumentNullException(nameof(productDetails));
            }
            var existingProduct =_productRepository.GetProductBySKUAsync(productDetails.SKU).Result;
            if (existingProduct != null)
            {
                throw new InvalidOperationException("A product with the same SKU already exists.");
            }
            var newProduct = new Product(productDetails.ProductName, productDetails.SKU, productDetails.PurchasePrice, productDetails.Category, productDetails.stockQuantity, productDetails.SellerID);
            await _productRepository.AddnewProduct(newProduct);
        }
    }
}
