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
    [Route("users/")]
    [ApiController]
    public class GolferAccountController : ControllerBase
    {
        private readonly GolferAccountService _userService;

        public GolferAccountController(GolferAccountService userService)
        {
            _userService = userService;
        }

        [HttpGet("login/{email}/{password}")]
        public ActionResult<bool> DoesDoesGolferExist(string email, string password)
        {
            return _userService.DoesGolferExist(email, password);
        }
    }
}