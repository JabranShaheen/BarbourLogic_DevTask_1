using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarbourLogic_DevTask_1.Abstractions;
using BarbourLogic_DevTask_1.Repositories;
using Moq;
using System.Collections.Generic;
using BarbourLogic_DevTask_1.Abstractions.Entities;
using BarbourLogic_DevTask_1.Abstractions.Repositories;

namespace BarbourLogic_DevTask_1.Test
{
    [TestClass]
    public class UserManagerTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private IUserManager _userManager;

        [TestInitialize]
        public void SetUp()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userManager = new UserManager(_mockUserRepository.Object);
        }

        [TestMethod]
        public void AddUser_ShouldAddUserToRepository()
        {
            // Arrange
            var user = new User { UserID = 1, Name = "Test User" };

            // Act
            _userManager.AddUser(user);

            // Assert
            _mockUserRepository.Verify(r => r.Add(user), Times.Once);
        }

        [TestMethod]
        public void UpdateUser_ShouldUpdateUserInRepository()
        {
            // Arrange
            var updatedUser = new User { UserID = 1, Name = "Updated User" };

            // Act
            _userManager.UpdateUser(1, updatedUser);

            // Assert
            _mockUserRepository.Verify(r => r.Update(1, updatedUser), Times.Once);
        }

        [TestMethod]
        public void DeleteUser_ShouldRemoveUserFromRepository()
        {
            // Arrange
            var userId = 1;

            // Act
            _userManager.DeleteUser(userId);

            // Assert
            _mockUserRepository.Verify(r => r.Delete(userId), Times.Once);
        }

        [TestMethod]
        public void GetUserById_ShouldReturnCorrectUser()
        {
            // Arrange
            var user = new User { UserID = 1, Name = "Test User" };
            _mockUserRepository.Setup(r => r.GetById(1)).Returns(user);

            // Act
            var retrievedUser = _userManager.GetUserById(1);

            // Assert
            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(user.Name, retrievedUser.Name);
            Assert.AreEqual(user.UserID, retrievedUser.UserID);
        }

        [TestMethod]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { UserID = 1, Name = "Test User 1" },
                new User { UserID = 2, Name = "Test User 2" }
            };
            _mockUserRepository.Setup(r => r.GetAll()).Returns(users);

            // Act
            var retrievedUsers = _userManager.GetAllUsers();

            // Assert
            Assert.AreEqual(2, retrievedUsers.Count());
        }
    }
}
