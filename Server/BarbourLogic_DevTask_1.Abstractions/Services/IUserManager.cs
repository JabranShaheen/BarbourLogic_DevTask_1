using BarbourLogic_DevTask_1.Abstractions.Entities;
using System.Collections.Generic;

namespace BarbourLogic_DevTask_1.Abstractions
{
    public interface IUserManager
    {
        void AddUser(User user);
        void UpdateUser(int userId, User updatedUser);
        void DeleteUser(int userId);
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
    }
}
