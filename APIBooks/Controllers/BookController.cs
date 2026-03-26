using APIBooks.DAL.Modes;
using APIBooks.Models;
using APIBooks.Service.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace APIBooks.Controllers
{
    [ApiController]
    [Route ("api")]
    public class BookController:ControllerBase
    {
        public IBooksSevice _bookShop {  get; set; }
        public IAPIService _api { get; set; }
        public BookController(IBooksSevice bookShop, IAPIService api)
        {
            _bookShop = bookShop;
            _api = api;
        }
        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody]BookDTO book)
        {
            _bookShop.AddBook(book);
            if (_bookShop.GetAllBooks().LastOrDefault().Title == book.Title)
            {
                return Ok(book);
            }
            return BadRequest();
        }
        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor([FromBody]AuthorDTO author)
        {
            _bookShop.AddAuthor(author);
            if (_bookShop.GetAllAuthors().LastOrDefault().FirstName == author.FirstName)
            {
                return Ok(author);
            }
            return BadRequest();
        }
        [HttpPost("DeleteBook")]
        public IActionResult DeleteBook([FromBody]int Id)
        {
            if(_bookShop.GetBookByID(Id) == null)
            {
                return BadRequest();
            }
            _bookShop.DeleteBook(Id);
            return Ok(_bookShop.GetAllBooks());
        }
        [HttpPost("DeleteAuthor")]
        public IActionResult DeleteAuthor([FromBody]int Id)
        {
            if (_bookShop.GetAuthorByID(Id) == null)
            {
                return BadRequest();
            }
            _bookShop.DeleteAuthor(Id);
            return Ok(_bookShop.GetAllAuthors());
        }
        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookShop.GetAllBooks());
        }
        [HttpGet("GetAllAuthors")]
        public IActionResult GetAllAuthors()
        {
            return Ok(_bookShop.GetAllAuthors());
        }

        [HttpPost ("UpdateBook")]
        public IActionResult UpdateBook([FromBody]BookDTO book)
        {
            if(book == null)
            {
                return BadRequest("We cant update info");
            }
            _bookShop.UpdateBook(book);
            return Ok(book);
        }
        [HttpPost ("UpdateAuthor")]
        public IActionResult UpdateAuthor([FromBody]AuthorDTO author)
        {
            if(author == null)
            {
                return BadRequest("We cant update info");
            }
            _bookShop.UpdateAuthor(author);
            return Ok(author);
        }
        [HttpGet ("GetAuthorById")]
        public IActionResult GetAuthorByID(int Id)
        {
            var author = _bookShop.GetAuthorByID(Id);
            if(author == null)
            {
                return BadRequest("Id is uncorrect");
            }
            return Ok(author);
        }
        [HttpGet("GetBookById")]
        public IActionResult GetBookByID(int Id)
        {
            var book = _bookShop.GetBookByID(Id);
            if (book == null)
            {
                return BadRequest("Id is uncorrect");
            }
            return Ok(book);
        }
        [HttpGet ("GetBooksByAuthorId")]
        public IActionResult GetBooksByAuthorId(int Id)
        {
            var books = _bookShop.GetBooksByAuthorId(Id);
            if(books == null)
            {
                return Ok("we have no books");
            }
            return Ok(books);
        }

        [HttpGet ("GetIncludes")]
        public IActionResult GetIncludes(string text)
        {
            List<BookDTO> books = new List<BookDTO>();
            foreach(var i in _bookShop.GetAllBooks())
            {
                if (i.Title.ToLower().Contains(text.ToLower()))
                {
                    books.Add(i);
                }
            }
            return Ok(books);
        }
    }
}
