using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Sem2FirstProject.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, Range(16, 100)]
        public int Age { get; set; }


    }
}
