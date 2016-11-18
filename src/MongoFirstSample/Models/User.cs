using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoFirstSample.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        [BsonElement("ProductId")]
        public int UserId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
    }
}
