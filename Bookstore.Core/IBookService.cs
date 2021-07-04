using System.Collections.Generic;

namespace Bookstore.Core
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book AddBook(Book book);
        Book GetBookById(string id);
        void RemoveBook(string id);
        Book UpdateBook(Book book);
    }
}