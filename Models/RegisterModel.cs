using System.ComponentModel.DataAnnotations;

namespace RecordingOfViolations.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(30, ErrorMessage = "Пароль не може бути меньше 6 і більше 30 символів", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "паролі не співпадають")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
