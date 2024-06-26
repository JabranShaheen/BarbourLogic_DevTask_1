using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarbourLogic_DevTask_1.Abstractions.Repositories;
using BarbourLogic_DevTask_1.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using BarbourLogic_DevTask_1.Abstractions.Entities;
using BarbourLogic_DevTask_1.Abstractions.Repositories;
using BarbourLogic_DevTask_1.Abstractions;

namespace BarbourLogic_DevTask_1.Test
{
    [TestClass]
    public class BookManagerTests
    {
        private Mock<IBookRepository> _mockBookRepository;
        private Mock<IUserRepository> _mockUserRepository;
        private IBookManager _bookManager;

        [TestInitialize]
        public void SetUp()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _bookManager = new BookManager(_mockBookRepository.Object, _mockUserRepository.Object);
        }

        [TestMethod]
        public void AddBook_ShouldAddBookToRepository()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", ISBN = "12345", IsAvailable = true };

            // Act
            _bookManager.AddBook(book);

            // Assert
            _mockBookRepository.Verify(r => r.Add(book), Times.Once);
        }

        [TestMethod]
        public void UpdateBook_ShouldUpdateBookInRepository()
        {
            // Arrange
            var updatedBook = new Book { Title = "Updated Book", Author = "Updated Author", ISBN = "12345", IsAvailable = true };

            // Act
            _bookManager.UpdateBook("12345", updatedBook);

            // Assert
            _mockBookRepository.Verify(r => r.Update("12345", updatedBook), Times.Once);
        }

        [TestMethod]
        public void DeleteBook_ShouldRemoveBookFromRepository()
        {
            // Arrange
            var isbn = "12345";

            // Act
            _bookManager.DeleteBook(isbn);

            // Assert
            _mockBookRepository.Verify(r => r.Delete(isbn), Times.Once);
        }

        [TestMethod]
        public void GetBookByISBN_ShouldReturnCorrectBook()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", ISBN = "12345", IsAvailable = true };
            _mockBookRepository.Setup(r => r.GetByISBN("12345")).Returns(book);

            // Act
            var retrievedBook = _bookManager.GetBookByISBN("12345");

            // Assert
            Assert.IsNotNull(retrievedBook);
            Assert.AreEqual(book.Title, retrievedBook.Title);
            Assert.AreEqual(book.Author, retrievedBook.Author);
            Assert.AreEqual(book.ISBN, retrievedBook.ISBN);
            Assert.AreEqual(book.IsAvailable, retrievedBook.IsAvailable);
        }

        [TestMethod]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Title = "Test Book 1", Author = "Test Author 1", ISBN = "12345", IsAvailable = true },
                new Book { Title = "Test Book 2", Author = "Test Author 2", ISBN = "67890", IsAvailable = true }
            };
            _mockBookRepository.Setup(r => r.GetAll()).Returns(books);

            // Act
            var retrievedBooks = _bookManager.GetAllBooks();

            // Assert
            Assert.AreEqual(2, retrievedBooks.Count());
        }

        [TestMethod]
        public void BorrowBook_ShouldSetBookAsUnavailableAndAddToUserBorrowedBooks()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", ISBN = "12345", IsAvailable = true };
            var user = new User { UserID = 1, Name = "Test User" };

            _mockBookRepository.Setup(r => r.GetByISBN("12345")).Returns(book);
            _mockUserRepository.Setup(r => r.GetById(user.UserID)).Returns(user);

            // Act
            _bookManager.BorrowBook("12345", user);

            // Assert
            Assert.IsFalse(book.IsAvailable);
            Assert.IsTrue(user.BorrowedBooks.Contains(book));
            _mockBookRepository.Verify(r => r.Update("12345", book), Times.Once);
            _mockUserRepository.Verify(r => r.Update(user.UserID, user), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BorrowBook_ShouldThrowExceptionIfBookIsUnavailable()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", ISBN = "12345", IsAvailable = false };
            var user = new User { UserID = 1, Name = "Test User" };

            _mockBookRepository.Setup(r => r.GetByISBN("12345")).Returns(book);

            // Act
            _bookManager.BorrowBook("12345", user);
        }

        [TestMethod]
        public void ReturnBook_ShouldSetBookAsAvailableAndRemoveFromUserBorrowedBooks()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", ISBN = "12345", IsAvailable = false };
            var user = new User { UserID = 1, Name = "Test User", BorrowedBooks = new List<Book> { book } };

            _mockBookRepository.Setup(r => r.GetByISBN("12345")).Returns(book);
            _mockUserRepository.Setup(r => r.GetById(user.UserID)).Returns(user);

            // Act
            _bookManager.ReturnBook("12345", user);

            // Assert
            Assert.IsTrue(book.IsAvailable);
            Assert.IsFalse(user.BorrowedBooks.Contains(book));
            _mockBookRepository.Verify(r => r.Update("12345", book), Times.Once);
            _mockUserRepository.Verify(r => r.Update(user.UserID, user), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReturnBook_ShouldThrowExceptionIfBookIsAlreadyAvailable()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", ISBN = "12345", IsAvailable = true };
            var user = new User { UserID = 1, Name = "Test User" };

            _mockBookRepository.Setup(r => r.GetByISBN("12345")).Returns(book);

            // Act
            _bookManager.ReturnBook("12345", user);
        }
    }
}
