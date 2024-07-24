using InventoryManagement.Domain.Entities;

namespace InventoryManagement.UI.Models.ProductViewModel
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        
    }

}
