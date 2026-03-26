using APIBooks.DAL.Modes;
using APIBooks.Models;

namespace APIBooks.Service.Interface
{
    public interface IBooksSevice
    {
        public void AddBook(BookDTO book);
        public void AddAuthor(AuthorDTO author);

        public void DeleteAuthor(int Id);
        public void DeleteBook(int Id);

        public BookDTO GetBookByID(int Id);
        public AuthorDTO GetAuthorByID(int Id);

        public List<BookDTO> GetAllBooks();
        public List<AuthorDTO> GetAllAuthors();

        public Author MapAuthorDTO_ToAuthor(AuthorDTO author);
        public AuthorDTO MapAuthor_ToAuthorDTO(Author author);

        public Book MapBookDTO_ToBook(BookDTO book);
        public BookDTO MapBook_ToBookDTO(Book book);
        public void UpdateAuthor(AuthorDTO author);
        public void UpdateBook(BookDTO book);
        public List<BookDTO> GetBooksByAuthorId(int Id);
    }
}
