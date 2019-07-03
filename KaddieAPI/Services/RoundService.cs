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

        public List<Round> GetRoundsForGolfer(string golferID)
        {
            var list = _rounds.Find(round => round.GolferID == golferID).ToList();
            return list;
        }

        public List<Round> GetSortedRoundsForGolferByDateMostRecent(string golferID)
        {
            return _rounds.Find(round => round.GolferID == golferID).SortByDescending(round => round.Date).ToList();
        }

        public Round SubmitRound(Round round)
        {
            int front9 = 0;
            int back9 = 0;
            int total = 0;
            for(int i = 0; i < 9; i++)
            {
                front9 += Convert.ToInt32(round.Scores.ElementAt(i));
            }

            for(int i = 9; i < 18; i++)
            {
                back9 += Convert.ToInt32(round.Scores.ElementAt(i));
            }

            total = front9 + back9;

            round.Scores.Insert(18, front9.ToString());
            round.Scores.Insert(19, back9.ToString());
            round.Scores.Insert(20, total.ToString());

            _rounds.InsertOne(round);
            return round;
        }
    }
}
