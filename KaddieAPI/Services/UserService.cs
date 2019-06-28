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
    public class UserService
    {
        IConfiguration configuration { get; }
        private readonly IMongoCollection<User> _users;
        private string _userEmail;
        private string _userPassword;


        public UserService(IKaddieDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public bool SignIn(string email, string password)
        {
            _userEmail = email;
            _userPassword = password;
            bool result = UserExists();
            return result;
        }

        public User CreateUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public bool UserExists()
        {
            var config = configuration.GetSection("CurrentUserSettings");
            config["Email"] = _userEmail;

            var list = _users.CountDocuments(user => user.Email == _userEmail && user.Password == _userEmail);
            if (list > 0)
            {
                return true;
            }
            return false;
        }
    }
}
