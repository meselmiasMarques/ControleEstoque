using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class StockMovement
    {
        public int StockMovementID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
        public string MovementType { get; set; } = string.Empty;
        public int? CustomerID { get; set; }
        public int? SupplierID { get; set; }

        public Product Product { get; set; } 
        public Customer Customer { get; set; }
        public Supplier Supplier { get; set; }
    }
}
