using BarbourLogic_DevTask_1.Abstractions;
using BarbourLogic_DevTask_1.Abstractions.Entities;
using BarbourLogic_DevTask_1.Abstractions.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BarbourLogic_DevTask_1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Update(int userId, User updatedUser)
        {
            var user = _users.FirstOrDefault(u => u.UserID == userId);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.BorrowedBooks = updatedUser.BorrowedBooks;
            }
        }

        public void Delete(int userId)
        {
            var user = _users.FirstOrDefault(u => u.UserID == userId);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public User GetById(int userId)  // Implemented method
        {
            return _users.FirstOrDefault(u => u.UserID == userId);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
    }
}
