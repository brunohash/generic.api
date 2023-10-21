using Application.Factory;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GenericApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly JwtFactory _jwtFactory; // Injete a fábrica de tokens JWT

        public AuthenticationController(IConfiguration configuration, JwtFactory jwtFactory)
        {
            _config = configuration;
            _jwtFactory = jwtFactory;
        }

        [HttpPost, Route("authenticate")]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            if (user == null)
            {
                return BadRequest("Requisição inválida.");
            }
            if (user.UserName == "root" && user.Password == "root")
            {
                var token = _jwtFactory.GenerateToken(user.UserName);

                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
