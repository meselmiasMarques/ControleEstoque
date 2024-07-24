using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class Order
    {
    

        public int OrderId { get; set; }
        public int CustomerId { get; set; } 
        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; } = new ();
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
