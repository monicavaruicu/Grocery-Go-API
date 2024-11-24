using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using GroceryGo_API.Services.Interface;
using GroceryGo_API.Repository.Interface;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using Microsoft.Extensions.Options;
using GroceryGo_API.Data;

namespace GroceryGo_API.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        public required IAuthenticationRepository AuthenticationRepository { get; set; }
        public required ConfigSettings ConfigurationSettings { get; set; }

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IOptions<ConfigSettings> options)
        {
            this.AuthenticationRepository = authenticationRepository;
            this.ConfigurationSettings = options.Value;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await AuthenticationRepository.GetUserByEmail(email);
        }

        public UserSessionDTO GenerateToken(User user)
        {
            var userclaim = new List<Claim>
            {
                new(ClaimTypes.Name, user.FirstName),
                new(ClaimTypes.Role, user.RoleId.ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationSettings.TokenSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: ConfigurationSettings.Issuer,
                audience: ConfigurationSettings.Audience,
                claims: userclaim,
                expires: DateTime.Now.AddHours(ConfigurationSettings.TokenExpiration),
                signingCredentials: creds
            );

            return new UserSessionDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Id = user.Id,
                RoleId = user.RoleId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            await AuthenticationRepository.Register(registerDTO);
        }
    }
}
