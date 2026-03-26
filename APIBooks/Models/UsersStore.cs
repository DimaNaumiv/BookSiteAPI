using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace APIBooks.Models
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }

    public sealed class UserRecord
    {
        public string Id;
        public string Email;
        public string PasswordHesh;
        public string Role;
    }

    public sealed class UsersStore
    {
        private readonly ConcurrentDictionary<string, UserRecord> _users = new();

        public UserRecord Find(string email)
        {
            if(email.IsNullOrEmpty())
            {
                return null;
            }
            _users.TryGetValue(email, out UserRecord user);
            return user;
        }

        public bool Create(string email,string password,string role)
        {
            if (email.IsNullOrEmpty() || password.IsNullOrEmpty() || role.IsNullOrEmpty())
            {
                return false;
            }

            if (_users.ContainsKey(email))
            {
                return false;
            }

            var user = new UserRecord() { 
                Id = Guid.NewGuid().ToString(),
                Email = email,
                PasswordHesh = password,
                Role = role
            };

            return _users.TryAdd(email, user);
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            foreach (var i in _users.Values)
            {
                users.Add(new User() {
                    Id = Guid.Parse(i.Id),
                    email = i.Email,
                    role = i.Role
                });
            }
            return users;
        }
        public bool ChangeRole(string email)
        {
            var userEntry = _users.FirstOrDefault(u => u.Value.Email == email);
            if (userEntry.Value != null)
            {
                userEntry.Value.Role = userEntry.Value.Role == "User" ? "Admin" : "User";
                return true;
            }
            return false;
        }
        

        public bool ChackPassword (UserRecord user,string password)
        {
            return user != null && Hesh(user.PasswordHesh) == Hesh(password);
        }

        private static string Hesh (string value)
        {
            using(var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value??""));
                return Convert.ToBase64String(bytes);
            };
        }
    }
}
