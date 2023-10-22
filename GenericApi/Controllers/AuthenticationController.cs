using Application.Handlers;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GenericApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtHandler _jwtHandler;

        public AuthenticationController(JwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserAuth user)
        {
            if (user == null)
            {
                return BadRequest("Requisição inválida.");
            }
            if (user.Username == "root" && user.Password == "root")
            {
                var token = _jwtHandler.GenerateToken(user.Username);

                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
