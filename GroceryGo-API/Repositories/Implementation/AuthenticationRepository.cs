using api.Repositories.Implementations;
using GroceryGo_API.Data;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repository.Interface;
using GroceryGo_API.Utils.Security;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GroceryGo_API.Repository.Implementation
{
    public class AuthenticationRepository(IConfiguration configuration, ApplicationDbContext dbContext) : BaseRepository(configuration), IAuthenticationRepository
    {
        public required ApplicationDbContext DbContext { get; set; } = dbContext;
        public required  PasswordHasher PasswordHasher { get; set; }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await DbContext.User.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            var existingUser = await DbContext.User.FirstOrDefaultAsync(u => u.Email == registerDTO.Email);

            if (existingUser != null)
            {
                return;
            }

            var newUser = new User
            {
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Password = PasswordHasher.HashPassword(registerDTO.Password)
            };

            DbContext.User.Add(newUser);
            await DbContext.SaveChangesAsync();

            return;
        }

}
}
