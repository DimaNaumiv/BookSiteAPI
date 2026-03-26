using APIBooks.DAL.Interface;
using APIBooks.DAL.Modes;
using APIBooks.Models;
using APIBooks.Service.Interface;

namespace APIBooks.Service
{
    public class BookService:IBooksSevice
    {
        public IBookRepository _bookRep {  get; set; }
        public BookService(IBookRepository bookRep)
        {
            _bookRep = bookRep;
        }

        public void AddBook(BookDTO book)
        {
            _bookRep.AddBook(MapBookDTO_ToBook(book));
        }
        public void AddAuthor(AuthorDTO author)
        {
            _bookRep.AddAuthor(MapAuthorDTO_ToAuthor(author));
        }

        public Author MapAuthorDTO_ToAuthor(AuthorDTO author)
        {
            return new Author() { 
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BirthYear = author.BirhthYear
            };
        }
        public AuthorDTO MapAuthor_ToAuthorDTO(Author author)
        {
            return new AuthorDTO()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BirhthYear = author.BirthYear
            };
        }

        public Book MapBookDTO_ToBook(BookDTO book)
        {
            return new Book()
            {
                Id=book.Id,
                Title = book.Title,
                PublisherYear = book.PublisherYear,
                ISBN = book.ISBN,
                Price = book.Price,
                authorId = book.authorId
            };
        }
        public BookDTO MapBook_ToBookDTO(Book book)
        {
            return new BookDTO()
            {
                Id = book.Id,
                Title = book.Title,
                PublisherYear = book.PublisherYear,
                ISBN = book.ISBN,
                Price = book.Price,
                authorId = book.authorId
            };
        }

        public void DeleteAuthor(int Id)
        {
            _bookRep.DeleteAuthor(Id);
        }
        public void DeleteBook(int Id)
        {
            _bookRep.DeleteBook(Id);
        }

        public BookDTO? GetBookByID(int Id)
        {
            Book? book = _bookRep.GetBook_ById(Id);
            if(book == null)
            {
                return null;
            }
            return MapBook_ToBookDTO(book);
        }
        public AuthorDTO? GetAuthorByID(int Id)
        {
            Author? author = _bookRep.GetAuthor_ById(Id);
            if(author == null)
            {
                return null;
            }
            return MapAuthor_ToAuthorDTO(author);
        }

        public List<BookDTO> GetAllBooks()
        {
            List<BookDTO> books = new List<BookDTO>();
            foreach(var i in _bookRep.GetAllBooks())
            {
                books.Add(MapBook_ToBookDTO(i));
            }
            return books;
        }
        public List<AuthorDTO> GetAllAuthors()
        {
            List<AuthorDTO> authors = new List<AuthorDTO>();
            foreach(var i in _bookRep.GetAllAuthor())
            {
                authors.Add(MapAuthor_ToAuthorDTO(i));
            }
            return authors;
        }
        public void UpdateAuthor(AuthorDTO author)
        {
            _bookRep.UpdateAuthor(MapAuthorDTO_ToAuthor(author));
        }
        public void UpdateBook(BookDTO book)
        {
            _bookRep.UpdateBook(MapBookDTO_ToBook(book));
        }
        public List<BookDTO> GetBooksByAuthorId(int Id)
        {
            List<BookDTO> books = new List<BookDTO>();
            foreach(var i in _bookRep.GetAllBooksByAuthorId(Id))
            {
                books.Add(MapBook_ToBookDTO(i));
            }
            return books;
        }
    }
}
