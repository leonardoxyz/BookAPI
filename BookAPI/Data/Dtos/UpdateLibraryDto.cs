using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Dtos;

public class UpdateLibraryDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório!")]
    public string Name { get; set; }
}
