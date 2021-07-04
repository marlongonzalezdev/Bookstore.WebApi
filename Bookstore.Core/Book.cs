using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bookstore.Core
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public Author Author { get; set; }
    }

    public class Author {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
