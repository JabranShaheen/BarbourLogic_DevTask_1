using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarbourLogic_DevTask_1.Abstractions;
using BarbourLogic_DevTask_1.Repositories;
using System.Linq;
using BarbourLogic_DevTask_1.Abstractions.Entities;
using BarbourLogic_DevTask_1.Abstractions.Repositories;

namespace BarbourLogic_DevTask_1.Test
{
    [TestClass]
    public class BookRepositoryTests
    {
        private IBookRepository _bookRepository;

        [TestInitialize]
        public void SetUp()
        {
            _bookRepository = new BookRepository();
        }

        [TestMethod]
        public void AddBook_ShouldAddBookToRepository()
        {
            // Arrange
            var book = new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                ISBN = "12345",
                IsAvailable = true
            };

            // Act
            _bookRepository.Add(book);
            var retrievedBook = _bookRepository.GetByISBN("12345");

            // Assert
            Assert.IsNotNull(retrievedBook);
            Assert.AreEqual(book.Title, retrievedBook.Title);
            Assert.AreEqual(book.Author, retrievedBook.Author);
            Assert.AreEqual(book.ISBN, retrievedBook.ISBN);
            Assert.AreEqual(book.IsAvailable, retrievedBook.IsAvailable);
        }

        [TestMethod]
        public void UpdateBook_ShouldUpdateBookInRepository()
        {
            // Arrange
            var book = new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                ISBN = "12345",
                IsAvailable = true
            };
            _bookRepository.Add(book);

            var updatedBook = new Book
            {
                Title = "Updated Book",
                Author = "Updated Author",
                ISBN = "12345",
                IsAvailable = false
            };

            // Act
            _bookRepository.Update("12345", updatedBook);
            var retrievedBook = _bookRepository.GetByISBN("12345");

            // Assert
            Assert.IsNotNull(retrievedBook);
            Assert.AreEqual(updatedBook.Title, retrievedBook.Title);
            Assert.AreEqual(updatedBook.Author, retrievedBook.Author);
            Assert.AreEqual(updatedBook.ISBN, retrievedBook.ISBN);
            Assert.AreEqual(updatedBook.IsAvailable, retrievedBook.IsAvailable);
        }

        [TestMethod]
        public void DeleteBook_ShouldRemoveBookFromRepository()
        {
            // Arrange
            var book = new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                ISBN = "12345",
                IsAvailable = true
            };
            _bookRepository.Add(book);

            // Act
            _bookRepository.Delete("12345");
            var retrievedBook = _bookRepository.GetByISBN("12345");

            // Assert
            Assert.IsNull(retrievedBook);
        }

        [TestMethod]
        public void GetByISBN_ShouldReturnCorrectBook()
        {
            // Arrange
            var book = new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                ISBN = "12345",
                IsAvailable = true
            };
            _bookRepository.Add(book);

            // Act
            var retrievedBook = _bookRepository.GetByISBN("12345");

            // Assert
            Assert.IsNotNull(retrievedBook);
            Assert.AreEqual(book.Title, retrievedBook.Title);
            Assert.AreEqual(book.Author, retrievedBook.Author);
            Assert.AreEqual(book.ISBN, retrievedBook.ISBN);
            Assert.AreEqual(book.IsAvailable, retrievedBook.IsAvailable);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllBooks()
        {
            // Arrange
            var book1 = new Book
            {
                Title = "Test Book 1",
                Author = "Test Author 1",
                ISBN = "12345",
                IsAvailable = true
            };
            var book2 = new Book
            {
                Title = "Test Book 2",
                Author = "Test Author 2",
                ISBN = "67890",
                IsAvailable = true
            };
            _bookRepository.Add(book1);
            _bookRepository.Add(book2);

            // Act
            var books = _bookRepository.GetAll().ToList();

            // Assert
            Assert.AreEqual(2, books.Count);
            Assert.IsTrue(books.Any(b => b.ISBN == "12345"));
            Assert.IsTrue(books.Any(b => b.ISBN == "67890"));
        }
    }
}
