using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Dtos;

public class ReadLibraryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ReadAddressDto ReadAddressDto { get; set; }
}
