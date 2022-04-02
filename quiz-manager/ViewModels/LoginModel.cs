using System.ComponentModel.DataAnnotations;
namespace quiz_manager.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}