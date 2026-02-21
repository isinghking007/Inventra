using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Application.DTOs
{
    public class UpdateProductDTO
    {
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public float? PurchasePrice { get; set; }
        public int? StockQuantity { get; set; }
    }
}
