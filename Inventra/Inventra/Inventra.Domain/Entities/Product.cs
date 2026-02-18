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
        public string ProductName { get; private set; }
        public string SKU { get; private set; }
        public float PurchasePrice { get; private set; }
        public string Category { get; private set; }

        public bool IsActive { get; private set; } = true;

        public int StockQuantity { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public int SellerID { get; private set; }

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
