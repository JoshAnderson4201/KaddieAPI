using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaddieAPI.Models
{
    public class CourseInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; }
        public string CourseName { get; set; }
        public List<string> TeesArray { get; set; }
        public List<string> SlopeArray { get; set; }
        public List<List<string>> YardsArray { get; set; }
        public List<string> ParsArray { get; set; }
        public List<string> LeaguesArray { get; set; }
    }
}
