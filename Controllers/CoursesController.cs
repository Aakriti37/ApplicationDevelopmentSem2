using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sem2FirstProject.Data;
using Sem2FirstProject.Data.Entities;
using System.Threading.Tasks;

namespace Sem2FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(AppDbContext dbContext) : ControllerBase
    {

        [HttpPost]
        public IActionResult AddCourses(Course course)
        {
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();

            return Ok("Course is Successfully Inserted");

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var allCourses = await dbContext.Courses.ToListAsync();

            return Ok(allCourses);
        }

        [HttpGet("modules")]
        public async Task<IActionResult> GetAllCoursesWithModules()
        {
            var allCoursesModules = await dbContext.Courses.Select(
                c => new { c.Id, c.Name, c.DurationYears, c.Modules }
                ).ToListAsync();

            return Ok(allCoursesModules);
        }

        [HttpGet("{id}/modules")]
        public async Task<IActionResult> GetModulesOfCourse(int id)
        {
            var listModulesOfCourse = await dbContext.Courses.Where( c => c.Id == id).Select(
                c => new { c.Name, ModuleCount = c.Modules.Count, c.Modules }
                ).ToListAsync();

            return Ok(listModulesOfCourse);
        }

        //[HttpGet("{id}/students")]
        //public async Task<IActionResult> GetStudentsOfCourse(int id)
        //{
        //    var course = await dbContext.Courses
        //        .Where(c => c.Id == id)
        //        .Select(c => new
        //        {
        //            c.Id,
        //            c.Name,
        //            StudentCount = c.Students.Count,
        //            Students = c.Students.Select(s => new
        //            {
        //                s.Id,
        //                FullName = s.FirstName + " " + s.LastName,
        //                s.Email,
        //                s.Phone
        //            })
        //        })
        //        .FirstOrDefaultAsync();

        //    if (course == null)
        //    {
        //        return NotFound("Course not found");
        //    }

        //    return Ok(course);
        //}
    }
}
