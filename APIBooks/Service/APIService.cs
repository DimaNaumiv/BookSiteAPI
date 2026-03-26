using APIBooks.Models;
using APIBooks.Models.ApiResponse;
using APIBooks.Service.Interface;
using System.Net.Http.Json;

namespace APIBooks.Service
{
    public class APIService:IAPIService
    {
        public HttpClient client { get; set; } = new HttpClient();
        public async Task<ApiResponse> GetBookById(int Id)
        {
            var response = await client.GetFromJsonAsync<ApiResponse>($"https://gutendex.com/books?ids={Id}");
            return response;
        }
        public async Task<ApiResponse> GetBookByLanguge(string lenguage)
        {
            var response = await client.GetFromJsonAsync<ApiResponse>($"https://gutendex.com/books?languages={lenguage}");
            return response;
        }
        public async Task<ApiResponse> GetBookByAuthorYearStart(int year)
        {
            var response = await client.GetFromJsonAsync<ApiResponse>($"https://gutendex.com/books?author_year_start ={year}");
            return response;
        }
        public async Task<ApiResponse> GetBookByAuthorYearEnded(int year)
        {
            var response = await client.GetFromJsonAsync<ApiResponse>($"https://gutendex.com/books?author_year_end={year}");
            return response;
        }
        public async Task<List<BookDTO>> GetBookByTitle(string title)
        {
            var response = await client.GetFromJsonAsync<ApiResponse>($"https://gutendex.com/books?search=%20{title}");
            List<BookDTO> books = new List<BookDTO>();
            foreach (var i in response.results)
            {
                var firstAuthor = i.authors?.FirstOrDefault();

                string[] authorParts = firstAuthor?.name?.Split(", ") ?? new string[] { "Невідомий", "" };
                BookDTO book = new BookDTO()
                {
                    Title = i.title,
                    ISBN = "Cudzi",
                    PublisherYear = i.authors.FirstOrDefault().death_year ?? 0,
                    Cover = i.formats.FirstOrDefault(f => f.Value.Contains(".cover")).Value,
                    Price = 55,
                    Author = new AuthorDTO()
                    {
                        FirstName = authorParts[0],
                        LastName = authorParts.Length > 1 ? authorParts[1] : "",
                        BirhthYear = i.authors.FirstOrDefault().birth_year ?? 0
                    }
                };
                if (book.Title.ToLower().Contains(title.ToLower()))
                {
                    if (books.Count == 0)
                    {
                        books.Add(book);
                    }
                    bool tf = false;
                    foreach(var b in books)
                    {
                        if (b.Title == book.Title)
                        {
                            tf = true;
                            break;
                        }
                    }
                    if(tf == false)
                    {
                        books.Add(book);
                    }
                }
            }
            return books;
        }
    }
}
