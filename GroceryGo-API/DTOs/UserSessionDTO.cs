using api.Enums;

namespace GroceryGo_API.DTOs
{
    public class UserSessionDTO
    {
        public required int Id { get; set; }
        public required string Token { get; set; }
        public UserRoleEnum RoleId { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
