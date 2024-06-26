using BarbourLogic_DevTask_1.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbourLogic_DevTask_1.Abstractions.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Update(string isbn, Book updatedBook);
        void Delete(string isbn);
        Book GetByISBN(string isbn);
        IEnumerable<Book> GetAll();
    }

}
