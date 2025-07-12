using BookHouse.Model;
using BookHouse.Repository.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace BookHouse.Repository.Concrete;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context) => _context = context;

    public async Task<List<Book>> GetAllAsync()
    {
       var books = await _context.Books.AsNoTracking().ToListAsync();
        return books ?? throw new KeyNotFoundException("Not found");
    }

    public async Task<Book> GetByIdAsync(int id)
    {
       var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
       return book ?? throw new KeyNotFoundException("Not found");
    }


    public async Task<Book> AddBookAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book;
    }


    public async Task<Book> UpdateBookAsync(Book book)
    {
        var updateBook = await _context.Books.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==book.Id);
        if (updateBook is null) throw new KeyNotFoundException();
        _context.Update(book);
        await _context.SaveChangesAsync();
        return updateBook ?? throw new KeyNotFoundException();
    }

    public async Task DeleteBookAsync(int id)
    {
        var deleteBook = await _context.Books.FirstOrDefaultAsync(x=> x.Id==id);
        _context.Books.Remove(deleteBook);
        await _context.SaveChangesAsync();

    }
}
