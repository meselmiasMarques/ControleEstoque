namespace InventoryManagement.Domain.Entities
{
    public class StockMovement
    {
        public int StockMovementId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; } 
        public string MovementType { get; set; } = string.Empty;
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }

        public Product? Product { get; set; } 
        public Customer? Customer { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
