using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Repository.Interface
{
    public interface IAuthenticationRepository
    {
        Task<User?> GetUserByEmail(string email);
        Task Register(RegisterDTO registerDTO);
    }
}
