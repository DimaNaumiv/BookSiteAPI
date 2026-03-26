using APIBooks.Models;
using APIBooks.Service;
using APIBooks.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIBooks.Controllers
{
    [ApiController]
    [Route("another/api")]
    public class AnatherApiController : Controller
    {
        private IAPIService _api { get; set; }
        public AnatherApiController(IAPIService api)
        {
            _api = api;
        }
        [HttpGet ("getBookByTitle")]
        public async Task<IActionResult> GetBookByTitle (string title)
        {
            var books = await _api.GetBookByTitle(title);
            return Ok(books);

        }
        [HttpGet("getBookById")]
        public async Task<IActionResult> GetBookById(int Id)
        {
            var res = await _api.GetBookById(Id);
            string[] athor = res.results.FirstOrDefault().authors.FirstOrDefault().name.Split(", ");
            var firstBook = res.results.FirstOrDefault();
            BookDTO book = new BookDTO()
            {
                Title = firstBook.title,
                ISBN = "Cudzi",
                PublisherYear = firstBook.authors.FirstOrDefault().death_year ?? 0,
                Price = 55,
                Cover = firstBook.formats.FirstOrDefault(f => f.Value.Contains(".cover")).Value,
                Author = new AuthorDTO()
                {
                    FirstName = athor[0],
                    LastName = athor.Length > 1 ? athor[1] : "",
                    BirhthYear = firstBook.authors.FirstOrDefault().birth_year ?? 0
                }
            };
            return Ok(book);

        }
        [HttpGet("getBooksByAuthorYearStart")]
        public async Task<IActionResult> GetBookByAuthorYearStarted(int start)
        {
            var res = await _api.GetBookByAuthorYearStart(start);
            List<BookDTO> books = new List<BookDTO>();
            foreach (var book in res.results)
            {
                string[] athor = book.authors.FirstOrDefault()?.name?.Split(", ") ?? new string[] { "Невідомий", "" }; ;
                BookDTO bookdto = new BookDTO()
                {
                    Title = book.title,
                    ISBN = "Cudzi",
                    PublisherYear = book.authors?.FirstOrDefault()?.death_year ?? 0,
                    Cover = book.formats.FirstOrDefault(f => f.Value.Contains(".cover")).Value,
                    Price = 55,
                    Author = new AuthorDTO()
                    {
                        FirstName = athor[0]??"",
                        LastName = athor.Length > 1 ? athor[1] : "",
                        BirhthYear = book.authors?.FirstOrDefault()?.birth_year ?? 0
                    }
                };
                books.Add(bookdto);
            }
            return Ok(books);

        }
        [HttpGet("getBooksByAuthorYearEnded")]
        public async Task<IActionResult> GetBookByYearEnded(int ended)
        {
            var res = await _api.GetBookByAuthorYearEnded(ended);
            List<BookDTO> books = new List<BookDTO>();
            foreach (var book in res.results)
            {
                string[] athor = book.authors.FirstOrDefault().name.Split(", ");
                BookDTO bookdto = new BookDTO()
                {
                    Title = book.title,
                    ISBN = "Cudzi",
                    PublisherYear = book.authors.FirstOrDefault().death_year??0,
                    Cover = book.formats.FirstOrDefault(f => f.Value.Contains(".cover")).Value,
                    Price = 55,
                    Author = new AuthorDTO()
                    {
                        FirstName = athor[0],
                        LastName = athor.Length > 1 ? athor[1] : "",
                        BirhthYear = book.authors.FirstOrDefault().birth_year??0
                    }
                };
                books.Add(bookdto);
            }
            return Ok(books);

        }
    }
}
