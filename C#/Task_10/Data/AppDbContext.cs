using BookServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookServiceAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
}
