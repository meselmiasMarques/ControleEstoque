using InventoryManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InventoryManagement.UI.Models.ProductViewModel
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "O campo Nome é Obrigatório")]
        [DisplayName("Nome")]
        [MaxLength(100, ErrorMessage = "O Campo Nome permite no máximo 100 Caracteres")]
        [MinLength(3, ErrorMessage = "O Campo Nome permite no Mínimo 3 Caracteres")]
        public string Name { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Preço é Obrigatório")]
        [DisplayName("Preço")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Digite um preço válido")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "O campo Categoria é Obrigatório")]
        [DisplayName("Categoria")]
        public Category Category { get; set; } = new Category();
        
    }

}
