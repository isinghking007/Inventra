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
    }
}
