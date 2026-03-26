using APIBooks.DAL.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBooks.DAL.Interface
{
    public interface IBookRepository
    {
        public void AddBook(Book book);
        public void AddAuthor(Author author);

        public void DeleteBook(int Id);
        public void DeleteAuthor(int Id);

        public List<Book> GetAllBooks();
        public List<Author> GetAllAuthor();

        public Author? GetAuthor_ById(int Id);
        public Book? GetBook_ById(int Id);

        public void UpdateBook(Book book);
        public void UpdateAuthor(Author author);

        public int GetAuthorIdByFirstNameLastName(string firstName,string lastName);
        public int GetBookIDByTitle(string title);

        public List<Book> GetAllBooksByAuthorId(int Id);

    }
}
