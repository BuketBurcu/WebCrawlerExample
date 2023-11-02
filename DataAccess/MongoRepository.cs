using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrawlerExample.DataAccess
{
    public class MongoRepository<T> : IRepository<T>, IDisposable where T : class
    {
        private IMongoDatabase _database;
        private IMongoCollection<T> _collection;
        private MongoClient _client;

        public MongoRepository()
        {
            GetDatabase();
            GetCollection();
        }

        private void GetCollection()
        {
            if (_database.GetCollection<T>(typeof(T).Name) == null)
                _database.CreateCollection(typeof(T).Name);
            _collection = _database.GetCollection<T>(typeof(T).Name);
        }

        private void GetDatabase()
        {
            _client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_URI"));
            _database = _client.GetDatabase(Environment.GetEnvironmentVariable("MONGO_DB"));
        }

        public void Add(T entity)
        {
            this._collection.InsertOne(entity);
        }

        public void Dispose()
        {

        }
    }
}
