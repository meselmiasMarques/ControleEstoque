using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.UI.Models.CategoryViewModel
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "O campo Nome é Obrigatório")]
        [DisplayName("Nome")]
        [MaxLength(100, ErrorMessage = "O Campo Nome permite no máximo 100 Caracteres")]
        [MinLength(3, ErrorMessage = "O Campo Nome permite no Mínimo 3 Caracteres")]
        public string Name { get; set; } = string.Empty;

    }
}
