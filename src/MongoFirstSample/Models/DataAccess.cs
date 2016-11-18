using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace MongoFirstSample.Models
{
    public class DataAccess {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("EmployeeDB");
        }

        public IEnumerable<User> GetUsers()
        {
            return _db.GetCollection<User>("User").FindAll();
        }


        public User GetUser(ObjectId id)
        {
            var res = Query<User>.EQ(p => p.Id, id);
            return _db.GetCollection<User>("User").FindOne(res);
        }

        public User Create(User p)
        {
            _db.GetCollection<User>("User").Save(p);
            return p;
        }

        public void Update(ObjectId id, User p)
        {
            p.Id = id;
            var res = Query<User>.EQ(pd => pd.Id, id);
            var operation = Update<User>.Replace(p);
            _db.GetCollection<User>("User").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<User>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<User>("User").Remove(res);
        }
    }
}
