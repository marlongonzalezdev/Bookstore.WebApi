using System.Collections.Generic;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public class BookService: IBookService
    {
        private readonly IMongoCollection<Book> _books; 

        public BookService(IDbClient dbClient)
        {
           _books =  dbClient.getBooksCollection();
        }
        public List<Book> GetBooks() => _books.Find(book => true).ToList();

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public Book GetBookById(string id) => _books.Find(book => book.Id == id).First();
        public void RemoveBook(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }

        public Book UpdateBook(Book book)
        {
            GetBookById(book.Id);
            _books.ReplaceOne(b=>b.Id == book.Id, book);
            return book;
        }
    }
}
