using System.Text.Json.Serialization;

namespace APIBooks.Models
{
    public class AuthModel
    {
        public sealed class RegisterRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public sealed class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

    }
    public sealed class RoleChangeRequest
    {
        public string Email { get; set; }
    }
    public sealed class AuthResponse
    {
        public string AccessToken { get; set; }
    }
}
