using System.ComponentModel.DataAnnotations;

namespace Sem2FirstProject.DTOs.Request
{
    public class RegisterUserDto
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Range(16, 100)]
        public int Age { get; set; }

    }
}
