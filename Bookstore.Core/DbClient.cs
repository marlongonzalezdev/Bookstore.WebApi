using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public class DbClient: IDbClient
    {
        private readonly IMongoCollection<Book> _books;
        public DbClient(IOptions<BookstoreConfig> bookstoreConfig)
        {
            var client = new MongoClient(bookstoreConfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreConfig.Value.Database_Name);
            _books = database.GetCollection<Book>(bookstoreConfig.Value.Books_Collection_Name);
        }

        public IMongoCollection<Book> getBooksCollection() => _books;
    }
}
