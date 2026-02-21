using Inventra.Application.DTOs;
using Inventra.Application.Interfaces;
using Inventra.Domain.Entities;
using Inventra.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Infrastructure.Repositories
{
    public class ProductRepository : IProductDetailsRepository
    {

        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddnewProduct(Product productDetails)
        {
            _dbContext.Products.Add(productDetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductDetailsDTO> GetProductBySKUAsync(string sku)
        {
            var productDetails = await _dbContext.Products.Where(p => p.SKU == sku && p.IsActive == true)
                .Select(p => new ProductDetailsDTO
                {
                    ProductName = p.ProductName,
                    SKU = p.SKU,
                    stockQuantity = p.StockQuantity,
                    PurchasePrice = p.PurchasePrice,
                    Category = p.Category,
                    SellerID = p.SellerID,
                    IsActive = p.IsActive
                }).FirstOrDefaultAsync();
            if (productDetails == null)
            {
                return null;
            }
            return productDetails;
        }

        public async Task<(List<Product>, int TotalRecords)> GetPagedAsync(int pageNumber, int pageSize, string searchTerm)
        {
            var query = _dbContext.Products.Where(p => p.IsActive == true &&
            (p.ProductName.Contains(searchTerm) || p.SKU.Contains(searchTerm))).AsQueryable();
            var totalRecords = await query.CountAsync();
            var data = await query.OrderBy(p => p.ProductId).
                Skip((pageNumber - 1) * pageSize).
                Take(pageSize).
                ToListAsync();
            return (data, totalRecords);
        }

        public async Task<ProductDetailsDTO> GetProductByIDAsync(int productId)
        {
            var productDetails = await _dbContext.Products.Where(p => p.ProductId == productId && p.IsActive == true)
               .Select(p => new ProductDetailsDTO
               {
                   SKU = p.SKU,
                   ProductName = p.ProductName,
                   PurchasePrice = p.PurchasePrice,
                   Category = p.Category,
                   SellerID = p.SellerID,
                   stockQuantity = p.StockQuantity,
                   IsActive = p.IsActive
               }).FirstOrDefaultAsync();
            return productDetails;
        }

        public async Task<ProductDetailsDTO?> UpdateProductDetails(int id, string productName, int newPrice, int newStockQuantity)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id && p.IsActive == true);
            if (product == null)
            {
                return null;
            }
            product.ProductName = productName;
            product.PurchasePrice = newPrice;
            product.StockQuantity = newStockQuantity;
            await _dbContext.SaveChangesAsync();

            return new ProductDetailsDTO
            {
                SKU = product.SKU,
                ProductName = product.ProductName,
                PurchasePrice = product.PurchasePrice,
                Category = product.Category,
                SellerID = product.SellerID,
                stockQuantity = product.StockQuantity,
                IsActive = product.IsActive
            };
        }

        public async Task<string> UpdateProductDetails(int productId, UpdateProductDTO updateProduct)
        {

            var productInfo = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId && p.IsActive == true);

            if (productInfo == null)
            {
                return "Product not found.";
            }
            if (updateProduct.PurchasePrice.HasValue && updateProduct.PurchasePrice.Value > 0)
            {
                productInfo.PurchasePrice = updateProduct.PurchasePrice.Value;
            }
            else if (updateProduct.ProductName != null && updateProduct.ProductName != "")
            {
                productInfo.ProductName = updateProduct.ProductName;
            }
            else if (updateProduct.StockQuantity.HasValue && updateProduct.StockQuantity.Value > 0)
            {
                productInfo.StockQuantity = updateProduct.StockQuantity.Value;
            }
            else if (updateProduct.Category != null && updateProduct.Category != "")
            {
                productInfo.Category = updateProduct.Category;
            }
            else
            {
                return "At least one field must be provided for update.";
            }
            await _dbContext.SaveChangesAsync();
            return "Details has been updated successfully";

        }
        public async Task<string> MakeInActiveProduct(int id)
        {
            var productInfo = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id && p.IsActive == true);
            if (productInfo == null)
            {
                return "Product not found.";
            }
            productInfo.IsActive = false;
            await _dbContext.SaveChangesAsync();
            return "Product has been made inactive successfully.";
        }



    }
}