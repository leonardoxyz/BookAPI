using AutoMapper;
using BookAPI.Data;
using BookAPI.Data.Dtos;
using BookAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : Controller
{
    private BookContext _context;
    private IMapper _mapper;

    public BookController(BookContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookDto bookDto)
    {
        if (bookDto == null)
        {
            return BadRequest("O livro enviado é inválido.");
        }

        Book book = _mapper.Map<Book>(bookDto);
        book.Id = Guid.NewGuid();
        _context.Books.Add(book);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }
    [HttpGet]
    public IEnumerable<ReadBookDto> GetBooks()
    {
        return _mapper.Map<List<ReadBookDto>>(_context.Books);
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(Guid id)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == id);
        if (book == null) return NotFound();

        var bookDto = _mapper.Map<ReadBookDto>(book);
        return Ok(bookDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(Guid Id, [FromBody] UpdateBookDto bookDto)
    {
        var book = _context.Books.FirstOrDefault(book=> book.Id == Id);
        if (book == null) return NotFound();
        _mapper.Map(bookDto, book);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateById(Guid Id, JsonPatchDocument<UpdateBookDto> patch)
    {
        var book = _context.Books.FirstOrDefault(book => book.Id == Id);
        if (book == null) return NotFound();

        var bookForUpdate = _mapper.Map<UpdateBookDto>(book);
        patch.ApplyTo(bookForUpdate, ModelState);

        if (!TryValidateModel(bookForUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(bookForUpdate, book);
        _context.SaveChanges();

        return CreatedAtAction(nameof(UpdateById), new { id = book.Id }, book);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(Guid Id) {
        var book = _context.Books.FirstOrDefault(book => book.Id == Id);
        if (book == null) return NotFound();
        _context.Remove(book);
        _context.SaveChanges();
        return NoContent();
    }
}
