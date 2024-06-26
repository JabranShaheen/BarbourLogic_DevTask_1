using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarbourLogic_DevTask_1.Abstractions;
using BarbourLogic_DevTask_1.Repositories;
using System.Linq;
using BarbourLogic_DevTask_1.Abstractions.Entities;
using BarbourLogic_DevTask_1.Abstractions.Repositories;

namespace BarbourLogic_DevTask_1.Test
{
    [TestClass]
    public class UserRepositoryTests
    {
        private IUserRepository _userRepository;

        [TestInitialize]
        public void SetUp()
        {
            _userRepository = new UserRepository();
        }

        [TestMethod]
        public void AddUser_ShouldAddUserToRepository()
        {
            // Arrange
            var user = new User
            {
                UserID = 1,
                Name = "Test User"
            };

            // Act
            _userRepository.Add(user);
            var retrievedUser = _userRepository.GetById(1);

            // Assert
            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(user.UserID, retrievedUser.UserID);
            Assert.AreEqual(user.Name, retrievedUser.Name);
        }

        [TestMethod]
        public void UpdateUser_ShouldUpdateUserInRepository()
        {
            // Arrange
            var user = new User
            {
                UserID = 1,
                Name = "Test User"
            };
            _userRepository.Add(user);

            var updatedUser = new User
            {
                UserID = 1,
                Name = "Updated User"
            };

            // Act
            _userRepository.Update(1, updatedUser);
            var retrievedUser = _userRepository.GetById(1);

            // Assert
            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(updatedUser.UserID, retrievedUser.UserID);
            Assert.AreEqual(updatedUser.Name, retrievedUser.Name);
        }

        [TestMethod]
        public void DeleteUser_ShouldRemoveUserFromRepository()
        {
            // Arrange
            var user = new User
            {
                UserID = 1,
                Name = "Test User"
            };
            _userRepository.Add(user);

            // Act
            _userRepository.Delete(1);
            var retrievedUser = _userRepository.GetById(1);

            // Assert
            Assert.IsNull(retrievedUser);
        }

        [TestMethod]
        public void GetById_ShouldReturnCorrectUser()
        {
            // Arrange
            var user = new User
            {
                UserID = 1,
                Name = "Test User"
            };
            _userRepository.Add(user);

            // Act
            var retrievedUser = _userRepository.GetById(1);

            // Assert
            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(user.UserID, retrievedUser.UserID);
            Assert.AreEqual(user.Name, retrievedUser.Name);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllUsers()
        {
            // Arrange
            var user1 = new User
            {
                UserID = 1,
                Name = "Test User 1"
            };
            var user2 = new User
            {
                UserID = 2,
                Name = "Test User 2"
            };
            _userRepository.Add(user1);
            _userRepository.Add(user2);

            // Act
            var users = _userRepository.GetAll().ToList();

            // Assert
            Assert.AreEqual(2, users.Count);
            Assert.IsTrue(users.Any(u => u.UserID == 1));
            Assert.IsTrue(users.Any(u => u.UserID == 2));
        }
    }
}
