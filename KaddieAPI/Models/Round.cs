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

        public string Id { get; set; }

        [BsonElement("GolferName")]
        public string GolferName { get; set; }
        public string CourseName { get; set; }
        public int Score { get; set; }
    }
}
