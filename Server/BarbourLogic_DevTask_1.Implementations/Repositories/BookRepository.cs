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
