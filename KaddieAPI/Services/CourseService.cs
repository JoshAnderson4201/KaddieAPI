using KaddieAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaddieAPI.Services
{
    public class CourseService
    {
        private readonly IMongoCollection<Course> _courses;


        public CourseService(IKaddieDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _courses = database.GetCollection<Course>(settings.CourseCollectionName);
        }

        public List<string> GetCourseNames()
        {
            return _courses.Distinct<string>("CourseName", "{}").ToList();
        }

        public Course GetCourseByID(string id)
        {
            return _courses.Find(course => course.Id == id).ToList().First();
        }

        public List<string> GetTeesForCourse(Course course)
        {
            return course.Tees;
        }

        public List<string> GetYardsForTees(Course course, List<string> tees, string teeName)
        {
            List<string> yardsList = new List<string>();
            var index = tees.IndexOf(teeName);
            var yards = course.Yards.ElementAt(index);
            return yards;
        }



    }
}
