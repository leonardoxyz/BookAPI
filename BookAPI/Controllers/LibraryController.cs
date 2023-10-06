using AutoMapper;
using BookAPI.Data.Dtos;
using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LibraryController : Controller
{
    private BookContext _context;
    private IMapper _mapper;

    public LibraryController(BookContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddLibrary([FromBody] CreateLibraryDto libraryDto)
    {
        if (libraryDto == null)
        {
            return BadRequest("A bibliotéca enviada é inválida.");
        }

        Library library = _mapper.Map<Library>(libraryDto);
        library.Id = Guid.NewGuid();
        _context.Libraries.Add(library);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetLibraryById), new { id = library.Id }, library);
    }
    [HttpGet]
    public IEnumerable<ReadLibraryDto> GetLibraries()
    {

        return _mapper.Map<List<ReadLibraryDto>>(_context.Libraries.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetLibraryById(Guid id)
    {
        var library = _context.Libraries.FirstOrDefault(library => library.Id == id);
        if (library == null) return NotFound();

        var libraryDto = _mapper.Map<ReadLibraryDto>(library);
        return Ok(libraryDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateLibrary(Guid Id, [FromBody] UpdateLibraryDto libraryDto)
    {
        var library = _context.Libraries.FirstOrDefault(library => library.Id == Id);
        if (library == null) return NotFound();
        _mapper.Map(libraryDto, library);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateById(Guid Id, JsonPatchDocument<UpdateLibraryDto> patch)
    {
        var library = _context.Libraries.FirstOrDefault(library => library.Id == Id);
        if (library == null) return NotFound();

        var libraryForUpdate = _mapper.Map<UpdateLibraryDto>(library);
        patch.ApplyTo(libraryForUpdate, ModelState);

        if (!TryValidateModel(libraryForUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(libraryForUpdate, library);
        _context.SaveChanges();

        return CreatedAtAction(nameof(UpdateById), new { id = library.Id }, library);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteLibrary(Guid Id)
    {
        var library = _context.Libraries.FirstOrDefault(library => library.Id == Id);
        if (library == null) return NotFound();
        _context.Remove(library);
        _context.SaveChanges();
        return NoContent();
    }
}
