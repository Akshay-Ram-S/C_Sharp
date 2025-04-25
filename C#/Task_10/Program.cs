using BookServiceAPI.Data;
using BookServiceAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB In-memory
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("BooksDb")); 

builder.Services.AddScoped<IBookService, BookService>();

// Exception handling
builder.Services.AddLogging();
builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext http) =>
{
    return Results.Problem("An unexpected error occurred.");
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
