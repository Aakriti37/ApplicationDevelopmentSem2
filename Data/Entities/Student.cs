namespace Sem2FirstProject.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;


        //public List<Course> Courses { get; set; } = [];

    }
}
