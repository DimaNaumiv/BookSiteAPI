using APIBooks.Core;
using APIBooks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace APIBooks.Controllers
{
    [ApiController]
    [Route ("api/auth")]
    public class AuthController:ControllerBase
    {
        private readonly UsersStore _users;
        private readonly JwtToken _jwt;
        public AuthController(UsersStore users, IConfiguration config)
        {
            _users = users;
            _jwt = new JwtToken(config);
        }
        [HttpPost ("Register")]
        public IActionResult Register (RegisterRequest register)
        {
            if (string.IsNullOrEmpty(register.Email)||string.IsNullOrEmpty(register.Password))
            {
                return BadRequest("email and password is required");
            }
            var ok = _users.Create(register.Email, register.Password,"User");
            return ok ? Ok() : Conflict("user allready exist");
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("email and password is required");
            }
            var user = _users.Find(request.Email);
            if (!_users.ChackPassword(user, request.Password))
            {
                return Unauthorized();
            }
            var Auth = new AuthResponse() { AccessToken = _jwt.Create(user) };
            return Ok(new { Auth.AccessToken ,user.Role ,user.Email});
        }
        [HttpPost ("createAdmin")]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult CreateAdmin(RegisterRequest register)
        {
            var ok = _users.Create(register.Email, register.Password, Roles.Admin);
            return ok ? Ok() : Conflict();
        }
        [HttpGet ("getAcounts")]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult GetAcounts()
        {
            return Ok(_users.GetAll());
        }
        [HttpPost ("changeRole")]
        public IActionResult ChangeRole([FromBody]RoleChangeRequest request)
        {
            bool tf = _users.ChangeRole(request.Email);
            if(tf == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
