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
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            _userService.CreateUser(user);
            return CreatedAtRoute("GetRound", new { id = user.InternalId.ToString() }, user);
        }
    }
}