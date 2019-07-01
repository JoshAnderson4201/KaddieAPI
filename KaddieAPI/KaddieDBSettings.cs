using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaddieAPI
{
    public class KaddieDBSettings : IKaddieDBSettings
    {
        public string RoundsCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string CourseCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IKaddieDBSettings
    {
        string RoundsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string CourseCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
