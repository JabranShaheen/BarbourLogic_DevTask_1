using BarbourLogic_DevTask_1.Abstractions.Entities;
using System.Collections.Generic;

namespace BarbourLogic_DevTask_1.Abstractions
{
    public interface IBookManager
    {
        void AddBook(Book book);
        void UpdateBook(string isbn, Book updatedBook);
        void DeleteBook(string isbn);
        Book GetBookByISBN(string isbn);
        IEnumerable<Book> GetAllBooks();
        void BorrowBook(string isbn, User user);
        void ReturnBook(string isbn, User user);
    }
}
