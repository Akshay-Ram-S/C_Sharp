using BookService.Models;

namespace BookService.Services;

public interface IBookService{
    Task<List<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<Book> CreateAsync(Book book);
    Task UpdateAsync(int id, Book book);
    Task DeleteAsync(int id);
}
