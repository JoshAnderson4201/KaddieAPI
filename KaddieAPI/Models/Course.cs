using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaddieAPI.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; }

        public string Id { get; set; }
        public string CourseName { get; set; }
        public List<string> Tees { get; set; }
        public List<List<string>> Yards { get; set; }
        public List<string> Par { get; set; }
        public List<string> Leagues { get; set; }
        
    }
}
