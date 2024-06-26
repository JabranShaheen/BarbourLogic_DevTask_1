using BarbourLogic_DevTask_1.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarbourLogic_DevTask_1.Abstractions.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(int userId, User updatedUser);
        void Delete(int userId);
        User GetById(int userId);
        IEnumerable<User> GetAll();
    }
}
