using System;
using System.Collections.Generic;
using System.Text;

namespace BarbourLogic_DevTask_1.Abstractions.Services
{
    public interface ILibraryManager
    {
        void BorrowBook(int userId, string isbn);
        void ReturnBook(int userId, string isbn);
    }
}
