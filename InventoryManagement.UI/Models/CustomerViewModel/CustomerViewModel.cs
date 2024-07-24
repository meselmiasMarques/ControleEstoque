using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.UI.Models.CustomerViewModel;

public class CustomerViewModel
{
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "O campo Nome é Obrigatório")]
    [DisplayName("Nome")]
    [MaxLength(100, ErrorMessage = "O Campo Nome permite no máximo 100 Caracteres")]
    [MinLength(3, ErrorMessage = "O Campo Nome permite no Mínimo 3 Caracteres")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Nome do contato")]
    [MaxLength(100, ErrorMessage = "O Campo só permite no máximo 100 Caracteres")]
    public string ContactName { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Endereço é Obrigatório")]
    [DisplayName("Endereço")]
    [MaxLength(100, ErrorMessage = "O Campo Endereço permite no máximo 100 Caracteres")]
    [MinLength(3, ErrorMessage = "O Campo Endereço permite no Mínimo 3 Caracteres")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Cidade é Obrigatório")]
    [DisplayName("Cidade")]
    [MaxLength(100, ErrorMessage = "O Campo Cidade permite no máximo 100 Caracteres")]
    [MinLength(3, ErrorMessage = "O Campo Cidade permite no Mínimo 3 Caracteres")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Telefone é Obrigatório")]
    [DisplayName("Telefone")]
    [MaxLength(100, ErrorMessage = "O Campo Telefone permite no máximo 100 Caracteres")]
    [MinLength(3, ErrorMessage = "O Campo Telefone permite no Mínimo 3 Caracteres")]
    public string Phone { get; set; } = string.Empty;
}