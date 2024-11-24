using api.Utils.Security;
using GroceryGo_API.DTOs;
using GroceryGo_API.Services.Interface;
using GroceryGo_API.Utils.Security;
using Microsoft.AspNetCore.Mvc;

namespace GroceryGo_API.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public required IAuthenticationService AuthenticationService { get; set; }
        public required PasswordHasher PasswordHasher { get; set; }

        public AuthenticationController(IAuthenticationService authenticationService, PasswordHasher passwordHasher)
        { 
            this.AuthenticationService = authenticationService;
            this.PasswordHasher = passwordHasher;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await AuthenticationService.GetUserByEmail(loginDTO.Email);
            if (user != null)
            {
                var passwordResult = PasswordHasher.VerifyHashedPassword(user.Password, loginDTO.Password);

                if (passwordResult == PasswordVerificationResult.Success)
                {
                    var token = AuthenticationService.GenerateToken(user);
                    return Ok(token);
                }
            }

            return Unauthorized("Could not verify Email and password");
        }

        [HttpPost("register")]
        public async Task Register([FromBody] RegisterDTO registerDTO)
        {
            registerDTO.Password = PasswordHasher.HashPassword(registerDTO.Password);
            await AuthenticationService.Register(registerDTO);
        }
    }
}
