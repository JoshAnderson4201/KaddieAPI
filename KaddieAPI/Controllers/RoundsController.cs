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

        [HttpGet("{golferName}")]
        public ActionResult<List<Round>> GetRoundsForGolfer(string golferName)
        {
            return _roundService.GetRoundsForGolfer(golferName);
        }

        [HttpPost]
        public ActionResult<Round> Create(Round round)
        {
            _roundService.Create(round);
            return CreatedAtRoute("GetRound", new { id = round.InternalId.ToString() }, round);
        }

    }
}