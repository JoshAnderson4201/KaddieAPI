using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaddieAPI.Models;
using KaddieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaddieAPI.Controllers
{
    [Route("courses/")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getNames")]
        public ActionResult<List<string>> GetCourseNames()
        {
            return _courseService.GetCourseNames();
        }

        [HttpGet("tees/{courseName}")]
        public ActionResult<List<string>> GetTees(string id)
        {
            var course = _courseService.GetCourseByID(id);
            return _courseService.GetTeesForCourse(course);
        }

        [HttpGet("tees/{courseId}/{tees}")]
        public ActionResult<List<string>> GetYardsForTees(string courseId, string tees)
        {
            var course = _courseService.GetCourseByID(courseId);
            var desiredTees = _courseService.GetTeesForCourse(course);
            return _courseService.GetYardsForTees(course, desiredTees, tees);
        }
    }
}