using Microsoft.EntityFrameworkCore;
using BookService.Data;
using BookService.Models;

namespace BookService.Services;

public class BookServiceImp : IBookService{
    private readonly BookContext _context;

    public BookServiceImp(BookContext context){
        _context = context;
    }

    public async Task<List<Book>> GetAllAsync() => await _context.Books.ToListAsync();

    public async Task<Book?> GetByIdAsync(int id) =>
        await _context.Books.FindAsync(id);

    public async Task<Book> CreateAsync(Book book){
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task UpdateAsync(int id, Book updatedBook){
        var book = await _context.Books.FindAsync(id);
        if (book == null) throw new Exception("Book not found");

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.Price = updatedBook.Price;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id){
        var book = await _context.Books.FindAsync(id);
        if (book == null) throw new Exception("Book not found");

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }
}
