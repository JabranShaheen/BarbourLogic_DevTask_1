using BarbourLogic_DevTask_1.Abstractions;
using BarbourLogic_DevTask_1.Abstractions.Entities;
using BarbourLogic_DevTask_1.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarbourLogic_DevTask_1.Repositories
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public BookManager(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
        }

        public void UpdateBook(string isbn, Book updatedBook)
        {
            _bookRepository.Update(isbn, updatedBook);
        }

        public void DeleteBook(string isbn)
        {
            _bookRepository.Delete(isbn);
        }

        public Book GetBookByISBN(string isbn)
        {
            return _bookRepository.GetByISBN(isbn);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public void BorrowBook(string isbn, User user)
        {
            var book = _bookRepository.GetByISBN(isbn);
            if (book == null || !book.IsAvailable)
            {
                throw new InvalidOperationException("Book is not available for borrowing.");
            }

            book.IsAvailable = false;
            user.BorrowedBooks.Add(book);
            _bookRepository.Update(isbn, book);
            _userRepository.Update(user.UserID, user);
        }

        public void ReturnBook(string isbn, User user)
        {
            var book = _bookRepository.GetByISBN(isbn);
            if (book == null || book.IsAvailable)
            {
                throw new InvalidOperationException("Book is not currently borrowed.");
            }

            book.IsAvailable = true;
            user.BorrowedBooks.Remove(book);
            _bookRepository.Update(isbn, book);
            _userRepository.Update(user.UserID, user);
        }


        public IEnumerable<Book> SearchBooks(string title, string author, string isbn)
        {
            var books = _bookRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(title))
            {
                books = books.Where(b => b.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                books = books.Where(b => b.Author.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            if (!string.IsNullOrWhiteSpace(isbn))
            {
                books = books.Where(b => b.ISBN.IndexOf(isbn, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            return books;
        }
    }
}
