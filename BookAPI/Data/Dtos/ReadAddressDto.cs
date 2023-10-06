using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Dtos;

public class ReadAddressDto
{
    public Guid Id { get; set; }
    public string Place { get; set; }
    public int Number { get; set; }
}
