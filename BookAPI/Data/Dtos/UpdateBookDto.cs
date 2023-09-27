using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Dtos;

public class UpdateBookDto
{
    [Required]
    public string Name { get; set; }
    [Required(ErrorMessage = "O gênero do livro é obrigatório!")]
    public string Genre { get; set; }
}
