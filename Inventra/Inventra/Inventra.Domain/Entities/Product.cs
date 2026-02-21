using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; private set; }
        public string ProductName { get;  set; }
        public string SKU { get;  set; }
        public float PurchasePrice { get;  set; }
        public string Category { get;  set; }

        public bool IsActive { get;  set; } = true;

        public int StockQuantity { get;  set; }
        public DateTime CreatedAt { get;  set; } = DateTime.Now;
        public int SellerID { get;  set; }

        protected Product() { }
        public Product(string productName, string sku, float purchasePrice, string category,int stockQuantity, int sellerID)
        {
            ProductName = productName;
            SKU = sku;
            PurchasePrice = purchasePrice;
            Category = category;
            SellerID = sellerID;
            StockQuantity = stockQuantity;
        }
    }
}
