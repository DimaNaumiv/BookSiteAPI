using APIBooks.Models;
using APIBooks.Models.ApiResponse;

namespace APIBooks.Service.Interface
{
    public interface IAPIService
    {
        public Task<ApiResponse> GetBookById(int Id);
        public Task<ApiResponse> GetBookByLanguge(string lenguage);
        public Task<ApiResponse> GetBookByAuthorYearStart(int year);
        public Task<ApiResponse> GetBookByAuthorYearEnded(int year);
        public Task<List<BookDTO>> GetBookByTitle(string title);
    }
}
