using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Dtos;

public class CreateAddressDto
{
    [Required(ErrorMessage = "O endereço da Biblíoteca é obrigatório!")]
    public string Place { get; set; }
    [Required(ErrorMessage = "O número do endereço da Biblíoteca é obrigatório!")]
    public int Number { get; set; }
}
