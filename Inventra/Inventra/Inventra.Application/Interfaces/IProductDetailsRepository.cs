using Inventra.Application.DTOs;
using Inventra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Application.Interfaces
{
    public interface IProductDetailsRepository
    {
        Task AddnewProduct(Product productDetails);
        Task<ProductDetailsDTO> GetProductBySKUAsync(string sku);
        Task<(List<Product>, int TotalRecords)> GetPagedAsync(int pageNumber, int pageSize,string? searchTerm);

        Task<ProductDetailsDTO> GetProductByIDAsync(int productId);

        Task<ProductDetailsDTO> UpdateProductDetails(int id, string productName,int newPrice,int newStockQuantity);
        //Task<bool> SoftDeleteProduct(int productId);
        Task<string> UpdateProductDetails(int productId, UpdateProductDTO updateProduct);

        Task<string> MakeInActiveProduct(int id);
    }
}
