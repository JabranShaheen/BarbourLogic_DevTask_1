using BarbourLogic_DevTask_1.Abstractions;
using BarbourLogic_DevTask_1.Abstractions.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BarbourLogic_DevTask_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookManager _bookManager;

        public BooksController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        [HttpGet("search")]
        public IActionResult SearchBooks(string title = null, string author = null, string isbn = null)
        {
            var books = _bookManager.SearchBooks(title, author, isbn);
            return Ok(books);
        }
    }
}