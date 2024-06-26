using BarbourLogic_DevTask_1.Abstractions;
using BarbourLogic_DevTask_1.Abstractions.Entities;
using BarbourLogic_DevTask_1.Abstractions.Repositories;
using System.Collections.Generic;

namespace BarbourLogic_DevTask_1.Repositories
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void UpdateUser(int userId, User updatedUser)
        {
            _userRepository.Update(userId, updatedUser);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
