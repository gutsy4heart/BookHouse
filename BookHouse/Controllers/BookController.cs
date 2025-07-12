using BookHouse.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using BookHouse.Model;
namespace BookHouse.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BookController : Controller
{
    private readonly IBookRepository _repos;

    public BookController(IBookRepository repos) => _repos = repos;

    #region Get

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    public async Task<IActionResult> GetAll()
    {
        var books = await _repos.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var bookByID = await _repos.GetByIdAsync(id);
        if (bookByID is null) { NotFound("Book is not found"); }
        return Ok(bookByID);
    }

    #endregion
    #region Create

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]

    public async Task<IActionResult> AddBook(Book book)
    {
        var newBook = await _repos.AddBookAsync(book);
        return Ok(newBook);
    }

    #endregion

    #region Update

    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    public async Task<IActionResult> UpdateBook(Book book)
    {
        var updateBook = await _repos.UpdateBookAsync(book);
        if (updateBook is null) { NotFound("Book is not found"); }
        return Ok(updateBook);

       
    }
    #endregion

    #region Delete
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]

    public async Task<IActionResult> DeleteBook(int id)
    {
        await _repos.DeleteBookAsync(id);
        return NoContent();
    }

    #endregion

}
