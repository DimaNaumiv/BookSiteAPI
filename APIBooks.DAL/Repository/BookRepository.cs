using APIBooks.DAL.Interface;
using APIBooks.DAL.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBooks.DAL.Repository
{
    public class BookRepository:IBookRepository
    {
        public AppDbContext _db;
        public BookRepository(AppDbContext db)
        {
            _db = db;
        }
        public void AddBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }
        public void AddAuthor(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
        }

        public void DeleteBook(int Id)
        {
            _db.Books.Remove(_db.Books.FirstOrDefault(b=>b.Id == Id));
            _db.SaveChanges();
        }
        public void DeleteAuthor(int Id)
        {
            _db.Authors.Remove(_db.Authors.FirstOrDefault(b => b.Id == Id));
            _db.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }
        public List<Author> GetAllAuthor()
        {
            return _db.Authors.ToList();
        }

        public Author? GetAuthor_ById(int Id)
        {
            return _db.Authors.FirstOrDefault(a => a.Id == Id);
        }
        public Book? GetBook_ById(int Id)
        {
            return _db.Books.FirstOrDefault(b => b.Id == Id);
        }
        public void UpdateBook(Book book)
        {
            var Book =_db.Books.FirstOrDefault(b => b.Id == book.Id);
            Book.Title = book.Title;
            Book.Price = book.Price;
            Book.PublisherYear = book.PublisherYear;
            Book.authorId = book.authorId;
            _db.SaveChanges();
        }
        public void UpdateAuthor(Author author)
        {
            var Author = _db.Authors.FirstOrDefault(a => a.Id == author.Id);
            Author.FirstName = author.FirstName;
            Author.LastName = author.LastName;
            Author.BirthYear = author.BirthYear;
            _db.SaveChanges();
        }
        public int GetAuthorIdByFirstNameLastName(string firstName, string lastName)
        {
            return _db.Authors.FirstOrDefault(a=>a.FirstName==firstName&&a.LastName==lastName).Id;
        }
        public int GetBookIDByTitle(string title)
        {
            return _db.Books.FirstOrDefault(b => b.Title == title).Id;
        }
        public List<Book> GetAllBooksByAuthorId(int Id)
        {
            return _db.Books.Where(b => b.authorId == Id).ToList();
        }
    }
}
