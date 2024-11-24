using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<User?> GetUserByEmail(string email);
        UserSessionDTO GenerateToken(User user);
        Task Register(RegisterDTO registerDTO);
    }
}
