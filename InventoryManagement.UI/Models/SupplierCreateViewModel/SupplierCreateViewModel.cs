using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InventoryManagement.UI.Models.SupplierCreateViewModel
{
    public class SupplierCreateViewModel
    {

        [Required(ErrorMessage = "O campo Nome é Obrigatório")]
        [DisplayName("Nome")]
        [MaxLength(100, ErrorMessage = "O Campo Nome permite no máximo 100 Caracteres")]
        [MinLength(3, ErrorMessage = "O Campo Nome permite no Mínimo 3 Caracteres")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo Nome do contato  é Obrigatório")]
        [DisplayName("Nome do Contato ")]
        [MaxLength(100, ErrorMessage = "O Campo Nome permite no máximo 100 Caracteres")]
        [MinLength(3, ErrorMessage = "O Campo Nome permite no Mínimo 3 Caracteres")]
        public string ContactName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Endereço é Obrigatório")]
        [DisplayName("Endereço")]
        [MaxLength(100, ErrorMessage = "O Campo Endereço permite no máximo 100 Caracteres")]
        [MinLength(3, ErrorMessage = "O Campo Endereço permite no Mínimo 3 Caracteres")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Cidade é Obrigatório")]
        [DisplayName("Cidade")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Telefone é Obrigatório")]
        [DisplayName("Telefone")]
        [MaxLength(100, ErrorMessage = "O Campo Telefone permite no máximo 100 Caracteres")]
        [MinLength(3, ErrorMessage = "O Campo Telefone permite no Mínimo 3 Caracteres")]
        public string Phone { get; set; } = string.Empty;
    }
}
