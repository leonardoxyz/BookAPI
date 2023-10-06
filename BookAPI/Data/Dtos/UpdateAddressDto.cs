using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Dtos;

public class UpdateAddressDto
{
    public string Place { get; set; }
    public int Number { get; set; }
}
