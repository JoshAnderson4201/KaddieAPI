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
    [Route("courseinfo/")]
    [ApiController]
    public class CourseInfoController : ControllerBase
    {
        private readonly CourseInfoService _courseInfoService;

        public CourseInfoController(CourseInfoService courseInfoService)
        {
            _courseInfoService = courseInfoService;
        }


        //Can you just use this method, and simply parse the JSON object in the client?
        [HttpGet("getInfo")]
        public CourseInfo GetCourseInfo()
        {
            return _courseInfoService.GetInfo();
        }

        [HttpGet("tees/")]
        public ActionResult<List<string>> GetTees(string id)
        {
            return _courseInfoService.GetTees();
        }

        [HttpGet("pars/")]
        public ActionResult<List<string>> GetPars()
        {
            return _courseInfoService.GetPars();
        }

        [HttpGet("yards/{teeID}")]
        public ActionResult<List<string>> GetYardsForTees(int teeID)
        {
            var course = GetCourseInfo();
            return _courseInfoService.GetYardsForTees(course, teeID);
        }

        [HttpGet("slope/{teeID}")]
        public ActionResult<string> GetSlopeForTees(int teeID)
        {
            return _courseInfoService.GetSlopeForTees(teeID);
        }
    }
}