using KaddieAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaddieAPI.Services
{
    public class GolferAccountService
    {
        IConfiguration configuration { get; }
        private readonly IMongoCollection<GolferAccount> _golferAccounts;


        public GolferAccountService(IKaddieDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _golferAccounts = database.GetCollection<GolferAccount>(settings.GolferAccountCollectionName);
        }

        public bool DoesGolferExist(string email, string password)
        {
            var golfer = _golferAccounts.Find(user => user.Email == email).ToList().First();
            if(golfer.Password == password)
            {
                return true;
            }
            return false;
        }

    }
}
