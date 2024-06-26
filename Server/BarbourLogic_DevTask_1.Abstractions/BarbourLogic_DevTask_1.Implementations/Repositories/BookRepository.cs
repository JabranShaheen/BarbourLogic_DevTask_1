using BarbourLogic_DevTask_1.Abstractions;
using BarbourLogic_DevTask_1.Abstractions.Entities;
using BarbourLogic_DevTask_1.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarbourLogic_DevTask_1.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public BookRepository()
        {
            _books = new List<Book>
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
        }

        public void Update(string isbn, Book updatedBook)
        {
            var book = _books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.IsAvailable = updatedBook.IsAvailable;
            }
        }

        public void Delete(string isbn)
        {
            var book = _books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

        public Book GetByISBN(string isbn)
        {
            return _books.FirstOrDefault(b => b.ISBN == isbn);
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }
    }
}
