using Inventra.Application.DTOs;
using Inventra.Application.Interfaces;
using Inventra.Domain.Entities;
using Inventra.Shared.Models;
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
            var existingProduct = _productRepository.GetProductBySKUAsync(productDetails.SKU).Result;
            if (existingProduct != null)
            {
                throw new InvalidOperationException("A product with the same SKU already exists.");
            }
            var newProduct = new Product(productDetails.ProductName, productDetails.SKU, productDetails.PurchasePrice, productDetails.Category, productDetails.stockQuantity, productDetails.SellerID);
            await _productRepository.AddnewProduct(newProduct);
        }

        public async Task<PagedResult<ProductDetailsDTO>> GetProductsAsync(int pageNumber, int pageSize, string? searchTerm)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 10;
            }
            if (pageSize > 100)
            {
                pageSize = 100;
            }
            var (products, totalRecords) = await _productRepository.GetPagedAsync(pageNumber, pageSize, searchTerm);

            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            return new PagedResult<ProductDetailsDTO>
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                Page = pageNumber,
                PageSize = pageSize,
                Data = products.Select(p => new ProductDetailsDTO
                {
                    ProductName = p.ProductName,
                    SKU = p.SKU,
                    PurchasePrice = p.PurchasePrice,
                    Category = p.Category,
                    stockQuantity = p.StockQuantity,
                    SellerID = p.SellerID,
                    IsActive = p.IsActive
                }).ToList()
            };


        }

        public async Task<ProductDetailsDTO> GetProductIDAsync(int productId)
        {
            if (productId < 1)
            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));
            }
            var productDetails = await _productRepository.GetProductByIDAsync(productId);
            if (productDetails == null)
            {
                throw new KeyNotFoundException($"No product found with ID: {productId}");
            }
            return productDetails;
        }

        public async Task<ProductDetailsDTO> UpdateProductDetails(int id, string productName, int newPrice, int newStockQuantity)
        {
            if(id<1)
            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(id));
            }
            var productInfo = await _productRepository.GetProductByIDAsync(id);
            if(productInfo == null)
            {
                throw new KeyNotFoundException($"No product found with ID: {id}");
            }
            var updatedProduct = await _productRepository.UpdateProductDetails(id, productName, newPrice, newStockQuantity);
            return updatedProduct;
        }

        public async Task<string> UpdateProductDetails(int id, UpdateProductDTO updateProduct)
        {
            if (id < 1)
            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(id));
            }
            return await _productRepository.UpdateProductDetails(id, updateProduct);
        }

        public async Task<ProductDetailsDTO> GetProductBySKU(string sku)
        {
            if(sku==null || sku.Length==0)
            {
                return null;
            }
            var productDetails= await _productRepository.GetProductBySKUAsync(sku);
            if(productDetails == null)
            {
                throw new KeyNotFoundException($"No product found with SKU: {sku}");
            }
            return productDetails;
        }

        public async Task<string> MakeInActiveProduct(int id)
        {
            if(id<1)
                            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(id));
            }
            return await _productRepository.MakeInActiveProduct(id);
        }
    }
}
