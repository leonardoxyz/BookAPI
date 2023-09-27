using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Dtos;

public class CreateBookDto
{
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O nome do livro é obrigatório!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O gênero do livro é obrigatório!")]
    public string Genre { get; set; }
}
