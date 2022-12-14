using System.ComponentModel.DataAnnotations;

namespace project.Models.DTO
{
    public class ForgotPasswordDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
