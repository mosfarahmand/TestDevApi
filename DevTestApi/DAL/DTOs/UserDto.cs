using System.ComponentModel;

namespace DevTestApi.DAL.DTOs
{
    [DisplayName("Users")]
    public class UserDto
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public string KnownAs { get; set; }

        public string Gender { get; set; }
    }
}