using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KaddieAPI.Models
{
    public class Round
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; }
        public string GolferID { get; set; }
        public DateTime Date { get; set; }
        public bool Completed { get; set; }
        public List<string> Scores { get; set; }
    }
}
