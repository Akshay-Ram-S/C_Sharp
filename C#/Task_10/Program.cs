using BookServiceAPI.Data;
using BookServiceAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB (InMemory or SQLite)
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("BooksDb")); // Use UseSqlite(...) for SQLite

builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
