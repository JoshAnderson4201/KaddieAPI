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
        public string GolferAccountCollectionName { get; set; }
        public string CourseInfoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IKaddieDBSettings
    {
        string RoundsCollectionName { get; set; }
        string GolferAccountCollectionName { get; set; }
        string CourseInfoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
