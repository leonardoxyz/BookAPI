using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models;

public class Address
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Place { get; set; }
    public int Number { get; set; }
    public virtual Library Library { get; set; }
}
