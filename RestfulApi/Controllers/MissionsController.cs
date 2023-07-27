using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestfulApi.Business.Services.Abstract;
using RestfulApi.Business.Services.Concrete;
using RestfulApi.Business.Validators;
using RestfulApi.Business.Extensions;
using RestfulApi.Models;
using RestfulApi.Business.Attributes;
using System.Collections.Generic;

namespace RestfulApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionsController : ControllerBase
    {

        private readonly List<Mission> _missions;
        private readonly IMissionService _missionService;
        private readonly IUserService _userService;

        public MissionsController(
            IMissionService missionService,
            IUserService userService)
        {
            _missionService = missionService;
            _userService = userService;

            _missions = _missionService.GetAllMissions();
        }



        [HttpGet]
        public IActionResult GetAllMissions()
        {
            if (_missions.Count == 0)
            {
                return Ok(new List<Mission>());
            }

            return Ok(_missions);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetMissionById(int id)
        {
            var mission = _missions.Find(s => s.Id == id);
            if (mission == null) {
                return NoContent();
         
            }
            var deadlineFormatted = _missionService.CustomDateFormat(mission);
            return Ok(new { Mission = mission, DeadlineFormatted = deadlineFormatted });
            
        }

        [HttpPost("login")]
        [UserAuthorize]

        public IActionResult Login([FromBody] User user)
        {
            if (_userService.Login(user.Username, user.Password))
            {
                return Ok("Login successful.");
            }

            return BadRequest("Invalid username or password.");
        }
        
    }
}
