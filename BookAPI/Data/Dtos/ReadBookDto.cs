using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Dtos;

public class ReadBookDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public DateTime TimeRequest { get; set; } = DateTime.Now;
}
