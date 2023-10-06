using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Dtos;

public class CreateLibraryDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório!")]
    public string Name { get; set; }
    [Required]
    public Guid AddressId { get; set; }
}
