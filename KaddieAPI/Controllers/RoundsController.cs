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
    [Route("rounds/")]
    [ApiController]
    public class RoundsController : ControllerBase
    {
        private readonly RoundService _roundService;

        public RoundsController(RoundService roundService)
        {
            _roundService = roundService;
        }

        [HttpGet]
        public ActionResult<List<Round>> GetAllRounds()
        {
            return _roundService.Get();
        }

        [HttpGet("{golferID}")]
        public ActionResult<List<Round>> GetRoundsForGolfer(string golferID)
        {
            return _roundService.GetRoundsForGolfer(golferID);
        }

        [HttpGet("date/{golferID}")]
        public ActionResult<List<Round>> GetSortedRoundsForGolferByDateMostRecent(string golferID)
        {
            return _roundService.GetSortedRoundsForGolferByDateMostRecent(golferID);
        }

        [HttpPost]
        public ActionResult<Round> SubmitRound(Round round)
        {
            return _roundService.SubmitRound(round);
        }

    }
}