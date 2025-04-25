using BookServiceAPI.Data;
using BookServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookServiceAPI.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.ToListAsync();

    public async Task<Book?> GetByIdAsync(int id) => await _context.Books.FindAsync(id);

    public async Task<Book> CreateAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<bool> UpdateAsync(int id, Book book)
    {
        var existing = await _context.Books.FindAsync(id);
        if (existing == null) return false;

        existing.Title = book.Title;
        existing.Author = book.Author;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return false;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }
}
