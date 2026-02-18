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
            var productDetails= await _dbContext.Products.Where(p => p.SKU == sku)
                .Select(p => new ProductDetailsDTO
                {
                    ProductName = p.ProductName,
                    SKU = p.SKU,
                    stockQuantity = p.StockQuantity,
                    PurchasePrice = p.PurchasePrice,
                    Category = p.Category,
                    SellerID = p.SellerID
                }).FirstOrDefaultAsync();
            if(productDetails == null)
            {
                return null;
            }
            return productDetails;
        }
    }
}
