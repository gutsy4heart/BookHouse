using BookHouse.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using BookHouse.Model;

namespace BookHouse.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _repository;

    public BooksController(IBookRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
    public async Task<IActionResult> GetAll()
    {
        var books = await _repository.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Book))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        return book is null ? NotFound() : Ok(book);
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Book))]
    public async Task<IActionResult> Create([FromBody] Book book)
    {
        var createdBook = await _repository.AddBookAsync(book);
        return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook(Book book)
    {
        var updatedBook = await _repository.UpdateBookAsync(book);
        return updatedBook is null ? NotFound() : Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _repository.DeleteBookAsync(id);
        return result ? NoContent() : NotFound();
    }
}