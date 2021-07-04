using MongoDB.Driver;

namespace Bookstore.Core
{
    public interface IDbClient
    {
        IMongoCollection<Book> getBooksCollection();
    }
}
