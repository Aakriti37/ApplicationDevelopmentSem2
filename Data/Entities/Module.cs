namespace Sem2FirstProject.Data.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Credits { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
