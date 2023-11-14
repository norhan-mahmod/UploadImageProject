using System.ComponentModel.DataAnnotations;

namespace ImageTask.MVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
