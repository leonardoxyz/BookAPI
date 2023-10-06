using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models;

public class Library
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo Nome é obrigatório!")]
    public string Name { get; set; }
    public Guid AddressId { get; set; }
    public virtual Address Address { get; set; }
}
