using BookHouse.Model;

namespace BookHouse.Repository.Abstract;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(int id);
    Task<Book> AddBookAsync(Book book);
    Task<Book> UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);

}
