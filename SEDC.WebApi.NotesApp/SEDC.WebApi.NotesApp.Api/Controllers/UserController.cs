using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.NotesApp.Models;
using SEDC.WebApi.NotesApp.Services.Exceptions;
using SEDC.WebApi.NotesApp.Services.Interfaces;
using System;
using System.Diagnostics;

namespace SEDC.WebApi.NotesApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel request)
        {
            try
            {
                _userService.Register(request);
                Debug.WriteLine($"User registered with {request.Username}");
                return Ok("Success");
            }
            catch (UserException ex)
            {
                Debug.WriteLine($"User {ex.UserId}.{ex.Name}: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unknown error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
