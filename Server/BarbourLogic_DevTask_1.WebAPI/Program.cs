using BarbourLogic_DevTask_1.Abstractions;
using BarbourLogic_DevTask_1.Abstractions.Entities;
using BarbourLogic_DevTask_1.Abstractions.Repositories;
using BarbourLogic_DevTask_1.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Seed data initialization
var books = new List<Book>
{
    new Book { Id = Guid.NewGuid().ToString(), Title = "Book 1", Author = "Author 1", ISBN = "1111111111", IsAvailable = true },
    new Book { Id = Guid.NewGuid().ToString(), Title = "Book 2", Author = "Author 2", ISBN = "2222222222", IsAvailable = true },
    new Book { Id = Guid.NewGuid().ToString(), Title = "Book 3", Author = "Author 3", ISBN = "3333333333", IsAvailable = true },
    new Book { Id = Guid.NewGuid().ToString(), Title = "Book 4", Author = "Author 4", ISBN = "4444444444", IsAvailable = true },
    new Book { Id = Guid.NewGuid().ToString(), Title = "Book 5", Author = "Author 5", ISBN = "5555555555", IsAvailable = true },
    new Book { Id = Guid.NewGuid().ToString(), Title = "Book 6", Author = "Author 6", ISBN = "6666666666", IsAvailable = true },
    new Book { Id = Guid.NewGuid().ToString(), Title = "Book 7", Author = "Author 7", ISBN = "7777777777", IsAvailable = true },
    new Book { Id = Guid.NewGuid().ToString(), Title = "Book 8", Author = "Author 8", ISBN = "8888888888", IsAvailable = true },
    new Book { Id = Guid.NewGuid().ToString(), Title = "Book 9", Author = "Author 9", ISBN = "9999999999", IsAvailable = true },
    new Book { Id = Guid.NewGuid().ToString(), Title = "Book 10", Author = "Author 10", ISBN = "1010101010", IsAvailable = true }
};

// Register dependencies
builder.Services.AddSingleton<IBookRepository>(provider =>
{
    var repository = new BookRepository();

    foreach (var book in books)
    {
        repository.Add(book); // Add each book individually to the repository
    }

    return repository;
});

builder.Services.AddSingleton<IBookManager, BookManager>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserManager, UserManager>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Enable CORS with specific policy
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
