using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaddieAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace KaddieAPI.Services
{
    public class RoundService
    {
        private readonly IMongoCollection<Round> _rounds;

        public RoundService(IKaddieDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _rounds = database.GetCollection<Round>(settings.RoundsCollectionName);
        }

        public List<Round> Get()
        {
            return _rounds.Find(round => true).ToList();
        }

        public List<Round> GetRoundsForGolfer(string golferName)
        {
            var list = _rounds.Find(round => round.GolferName == golferName).ToList();
            return list;
        }

        public Round Create(Round round)
        {
            _rounds.InsertOne(round);
            return round;
        }

    }
}
