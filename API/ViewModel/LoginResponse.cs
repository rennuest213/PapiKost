using API.Models;
using System.Text.Json.Serialization;

namespace API.ViewModel
{
    public class LoginResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        [JsonIgnore]
        public Role? role { get; set; }

        public string Role { get; set; }
    }
}
