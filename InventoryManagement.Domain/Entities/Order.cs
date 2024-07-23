using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; } 
        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; }    

        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    }
}
