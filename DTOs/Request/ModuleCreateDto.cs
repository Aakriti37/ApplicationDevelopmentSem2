using Sem2FirstProject.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Sem2FirstProject.DTOs.Request
{
    public class ModuleCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Range(10, 30)]
        public int Credits {  get; set; }

        [Range(1, int.MaxValue)]
        public int CourseId { get; set; }
        //public Course Course { get; set; }
    }
}
