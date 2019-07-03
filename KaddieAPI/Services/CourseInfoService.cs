using KaddieAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaddieAPI.Services
{
    public class CourseInfoService
    {
        private readonly IMongoCollection<CourseInfo> _courseInfo;


        public CourseInfoService(IKaddieDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _courseInfo = database.GetCollection<CourseInfo>(settings.CourseInfoCollectionName);
        }
        
        public CourseInfo GetInfo()
        {
            return _courseInfo.Find(_ => true).ToList().First();
        }

        public List<string> GetCourseNames()
        {
            return _courseInfo.Distinct<string>("CourseName", "{}").ToList();
        }

        public List<string> GetTees()
        {
            return _courseInfo.Distinct<string>("TeesArray", "{}").ToList();
        }

        public string GetSlopeForTees(int teeID)
        {
            var slopeArray = _courseInfo.Distinct<string>("SlopeArray", "{}").ToList();
            return slopeArray.ElementAt(teeID);
        }

        public List<string> GetYardsForTees(CourseInfo course, int teeID)
        {
            return course.YardsArray.ElementAt(teeID);
        }

        public List<string> GetPars()
        {
            return _courseInfo.Distinct<string>("ParsArray", "{}").ToList();
        }



    }
}
