using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevTestApi.DAL.DTOs
{
    [DisplayName("Login")]
    public class LoginDto
    {
        /// <summary>
        /// Username, Example: John
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}