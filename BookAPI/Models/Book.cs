using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models;

public class Book
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
}
