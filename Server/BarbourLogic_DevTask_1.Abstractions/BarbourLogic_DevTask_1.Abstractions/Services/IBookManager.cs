using BarbourLogic_DevTask_1.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbourLogic_DevTask_1.Abstractions.Services
{
    public interface IBookManager
    {
        void AddBook(Book book);
        void UpdateBook(string isbn, Book updatedBook);
        void DeleteBook(string isbn);
    }
}
