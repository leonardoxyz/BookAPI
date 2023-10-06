using AutoMapper;
using BookAPI.Data.Dtos;
using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private BookContext _context;
        private IMapper _mapper;

        public AddressController(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] CreateAddressDto addressDto)
        {
            if (addressDto == null)
            {
                return BadRequest("O endereço enviado é inválido.");
            }

            Address address = _mapper.Map<Address>(addressDto);
            address.Id = Guid.NewGuid();
            _context.Addresses.Add(address);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
        }

        [HttpGet]
        public IEnumerable<ReadAddressDto> GetAddresses()
        {
            return _mapper.Map<List<ReadAddressDto>>(_context.Addresses);
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(Guid id)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null) return NotFound();

            var addressDto = _mapper.Map<ReadAddressDto>(address);
            return Ok(addressDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress(Guid Id, [FromBody] UpdateAddressDto addressDto)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == Id);
            if (address == null) return NotFound();
            _mapper.Map(addressDto, address);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid Id, JsonPatchDocument<UpdateAddressDto> patch)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == Id);
            if (address == null) return NotFound();

            var addressForUpdate = _mapper.Map<UpdateAddressDto>(address);
            patch.ApplyTo(addressForUpdate, ModelState);

            if (!TryValidateModel(addressForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(addressForUpdate, address);
            _context.SaveChanges();

            return CreatedAtAction(nameof(UpdateById), new { id = address.Id }, address);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(Guid Id)
        {
            var address = _context.Addresses.FirstOrDefault(address => address.Id == Id);
            if (address == null) return NotFound();
            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
