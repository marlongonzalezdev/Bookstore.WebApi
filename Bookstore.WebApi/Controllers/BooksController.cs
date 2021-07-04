using Bookstore.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookstore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtRoute(nameof(GetBook), new {id = book.Id}, book);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(string id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpDelete]
        public IActionResult RemoveBook(string id)
        {
            _bookService.RemoveBook(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
           var updatedBook = _bookService.UpdateBook(book);
           return Ok(updatedBook);
        }
    }
}
