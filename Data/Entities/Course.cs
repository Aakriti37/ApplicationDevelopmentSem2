using System.ComponentModel.DataAnnotations;

namespace Sem2FirstProject.Data.Entities
{

    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public int DurationYears { get; set; }

        public List<Module> Modules { get; set; } = [];  // Navigation Property
        //public List<Student> Students { get; set; } = [];
    }
}
