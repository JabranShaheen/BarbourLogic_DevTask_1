using BarbourLogic_DevTask_1.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbourLogic_DevTask_1.Abstractions.Services
{
    public interface IUserManager
    {
        void AddUser(User user);
        void UpdateUser(int userId, User updatedUser);
        void DeleteUser(int userId);
    }
}
