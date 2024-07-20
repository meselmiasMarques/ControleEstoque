using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }
        public ICollection<StockMovement> StockMovements { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
