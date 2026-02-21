using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Application.DTOs
{
    public class ProductDetailsDTO
    {
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public float PurchasePrice { get; set; }
        public string Category { get; set; }
        public int SellerID { get; set; }
        public int stockQuantity { get; set; }

        public bool IsActive { get; set; }

    }
}
