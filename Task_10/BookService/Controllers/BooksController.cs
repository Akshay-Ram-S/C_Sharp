using Microsoft.AspNetCore.Mvc;
using BookService.Models;
using BookService.Services;

namespace BookService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase{
    private readonly IBookService _service;
    private readonly ILogger<BooksController> _logger;

    public BooksController(IBookService service, ILogger<BooksController> logger){
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks(){
        _logger.LogInformation("Fetching all books");
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id){
        var book = await _service.GetByIdAsync(id);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(Book book){
        var created = await _service.CreateAsync(book);
        return CreatedAtAction(nameof(GetBook), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book book){
        try{
            await _service.UpdateAsync(id, book);
        }
        catch (Exception e){
            return NotFound(e.Message);
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id){
        try{
            await _service.DeleteAsync(id);
        }
        catch (Exception e){
            return NotFound(e.Message);
        }
        return NoContent();
    }
}
