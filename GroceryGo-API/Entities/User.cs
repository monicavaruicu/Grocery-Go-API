﻿using api.Enums;

namespace GroceryGo_API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public UserRoleEnum RoleId { get; set; }
    }
}
