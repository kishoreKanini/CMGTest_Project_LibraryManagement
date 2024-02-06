using LibraryManagement.DataAccessLayer.Entity;
using LibraryManagement.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService booksService;

        public BooksController(BooksService booksService) 
        {
            this.booksService = booksService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            var books = this.booksService.GetAllBooks();
            return books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{Book_Title}")]
        public Book Search_BookFromLibrary(string book_Title)
        {
            var book = this.booksService.Search_BookFromLibrary(book_Title);
            return book;
        }

        // POST api/<BooksController>
        [HttpPost]
        public Task AddBooksToLibrary([FromBody] Book add_Book)
        {
            this.booksService.AddBooksToLibrary(add_Book);
            return Task.CompletedTask;
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public Task Remove_BooksFromLibrary(int book_Id)
        {
            this.booksService.Remove_BooksFromLibrary(book_Id);
            return Task.CompletedTask;
        }
    }
}
