using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class PasswordRequest
    {

        [Required]
        public string Password { get; set; }
    }
}