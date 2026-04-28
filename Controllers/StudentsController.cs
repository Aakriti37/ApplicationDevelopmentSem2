using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sem2FirstProject.Models;

namespace Sem2FirstProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StudentsController(IConfiguration config) : ControllerBase
    {
        public static List<Student> students = [];

        [HttpPost("add")]
        public IActionResult AddStudent([FromBody] Student newStudent)
        {
            if (students.Any(s => s.Id == newStudent.Id))
            {
                return BadRequest("Student with this ID already exists.");
            }

            students.Add(newStudent);

            return Ok("Student added successfully.");
        }


        [HttpGet("getall")]
        public List<Student> SendAllStudents()
        {
            return students;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            Student? student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound("Student Not Found.");
            }

            return Ok(student);

        }


        [HttpPut("update/{id}")]
        public IActionResult UpdateStudent(int id, Student updateStudent)
        {
            Student? student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound($"Student having id: {id} not found.");
            }

            student.Name = updateStudent.Name;
            student.Email = updateStudent.Email;
            student.age = updateStudent.age;

            return Ok("Student details updated successfully.");
        }


        [HttpDelete("delete/{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound($"Student having id: {id} not found.");
            }

            students.Remove(student);

            return Ok($"Student with {id} deleted successfully.");

        }


        //[HttpGet("setting")]
        //public IActionResult GetStudentFromSetting()
        //{
        //    int id = Convert.ToInt32(config["Student:Id"]);
        //    string name = config["Student:Name"]!;  // ! helps to tell the object that we know the value exist. 
        //    string email = config["Student:Email"]!;    // without ! it shows that variable can be nullable too.
        //    int age = Convert.ToInt32(config["Student:Age"]);

        //    //return Ok(
        //    //    new {id, name, email, age}   // Anonymous Object: Object without name
        //    //    );


        //    return Ok(new Student { Id = id, Name = name, Email = email, age = age });

        //}


        [HttpGet("setting")]
        public IActionResult GetStudentFromSetting(IOptions<Student> options)
        {
            Student student = options.Value;

            return Ok(student);

        }
    }
}
